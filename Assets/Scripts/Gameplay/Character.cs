using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

public enum CharacterRole
{
    Main,
    Drone
}

public class Character : Entity {

	public Text DebugText;

    public CharacterRole Role;

    private string _hAxis, _vAxis;

    public Vector3 Destination;
    private bool _isAtDestination;
    private bool _isSearchingPath;

    private List<VectorLine> _laserLines = new List<VectorLine>();

    private int _laserLayerMask;

    private Seeker _seeker;

    private PathInterpolator _interpolator = new PathInterpolator();
    private ABPath _path;
    private IMovementPlane _movementPlane;

    protected new void Start()
    {
        base.Start();

        _laserLayerMask = LayerMask.GetMask("Geometry", "Enemies");

        Destination = transform.position;

        _hAxis = Role == CharacterRole.Main ? "CharacterHorizontal" : "DroneHorizontal";
        _vAxis = Role == CharacterRole.Main ? "CharacterVertical" : "DroneVertical";

        var points = new List<Vector3>
        {
            Vector3.zero,
            Vector3.zero,
        };
        var line = new VectorLine("Laser1", points, 3.0f, LineType.Continuous, Joins.Weld);
        line.SetColor(new Color32(10, 10, 200, 255));
        _laserLines.Add(line);

        _seeker = GetComponent<Seeker>();

        if (_seeker)
        {
            _seeker.pathCallback += OnPathComplete;
        }
    }

    protected new void Update()
    {
        base.Update();

        if (Role == CharacterRole.Drone && !_isSearchingPath && Input.GetButtonDown("Fire2"))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.IntersectXY();
            Destination = point;
            _seeker.StartPath(transform.position, Destination);
            _isSearchingPath = true;
        }

        {
            Vector2 direction;

            if (Role == CharacterRole.Main)
            {
                direction.x = Input.GetAxisRaw(_hAxis);
                direction.y = Input.GetAxisRaw(_vAxis);

                if (Mathf.Abs(direction.x) < DeadZone) direction.x = 0.0f;
                else direction.x = Mathf.Sign(direction.x);

                if (Mathf.Abs(direction.y) < DeadZone) direction.y = 0.0f;
                else direction.y = Mathf.Sign(direction.y);
                _velocity += direction * Acceleration * Time.deltaTime;
            }
            else
            {
                if (!_interpolator.valid || _isAtDestination)
                {
                    _velocity = Vector3.zero;
                }
                else
                {
                    var position = transform.position;

                    _interpolator.MoveToLocallyClosestPoint(position, true, false);
                    _interpolator.MoveToCircleIntersection2D(position, 0.5f, _movementPlane);
                    var target = _interpolator.position;
                    Vector2 dir = target - position;

                    var distance = dir.magnitude + _interpolator.remainingDistance;

                    if (distance <= StopThreshold)
                    {
                        _isAtDestination = true;
                    }
                    else
                    {
                        var acceleration = Acceleration * dir.normalized * distance;
                        var damping = _velocity * 2.0f * Mathf.Sqrt(Acceleration);
                        _velocity += (acceleration - damping) * Time.deltaTime;
                    }
                }
            }
        }

        if (Input.GetButton("Fire1") && _game.Energy >=_game.EnergyNeedForFire)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.IntersectXY();

            var position = transform.position;

            var points = _laserLines[0].points3;
            points.Clear();
            points.Add(position);
            var direction = (point - position).normalized;

            for (var i = 0; i < 2; i++)
            {
                var hit = Physics2D.Raycast(position, direction, 20.0f, _laserLayerMask);
                if (hit.collider == null)
                {
                    points.Add(position + direction * 20.0f);
                    break;
                }

                points.Add(hit.point);

                var enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.DoLaserHit(_game.LaserDamage * Time.deltaTime);
                    float ed = _game.EnergyDrain * Time.deltaTime;
                    if (_game.Energy >= ed)
                    {
                        _game.Energy -= ed;
                        _game.EnergySpent += ed;
                    }
                    else {
                        _game.Energy = 0;
                    }
                    break;
                }

                direction = Vector2.Reflect(direction, hit.normal);
                position = (Vector3)hit.point + direction * 0.05f;
            }

            _laserLines[0].active = true;
            _laserLines[0].Draw();
        }
        else
        {
            _laserLines[0].active = false;
        }
    }

    private void OnPathComplete(Path path)
    {
        path.Claim(this);
        _isSearchingPath = false;
        _isAtDestination = false;

        if (path.error)
        {
            path.Release(this);
            return;
        }

        if (_path != null) _path.Release(this);

        _path = path as ABPath;

        var graph = AstarData.GetGraph(path.path[0]) as ITransformedGraph;
        _movementPlane = graph != null ? graph.transform : GraphTransform.identityTransform;
        
        if (_path.vectorPath.Count == 1)
        {
            _path.vectorPath.Add(_path.vectorPath[0]);
        }

        _interpolator.SetPath(_path.vectorPath);

        var position = transform.position;
        _interpolator.MoveToLocallyClosestPoint((position + _path.originalStartPoint) * 0.5f);
        _interpolator.MoveToLocallyClosestPoint(position);
    }
}
