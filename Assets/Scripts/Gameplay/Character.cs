using System;
using System.Collections;
using System.Collections.Generic;
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

    public GameObject DroneMarker;
    private bool isMoving;

    private List<VectorLine> _laserLines = new List<VectorLine>();

    private int _laserLayerMask;

    protected new void Start()
    {
        base.Start();

        _laserLayerMask = LayerMask.GetMask("Geometry", "Enemies");

        DroneMarker = new GameObject();
        
        DroneMarker.transform.position = transform.position;
        DroneMarker.transform.rotation = _game.Drone.transform.rotation;

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
    }

    protected new void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.IntersectXY();
            DroneMarker.transform.position = point;
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

                base.Update();
            }
            else
            {
                GetComponent<AIPath>().target = DroneMarker.transform;

                //var position = transform.position;
                //var distance = Destination - (Vector2)position;

                //var acceleration = Acceleration * distance;
                //var damping = _velocity * 2.0f * Mathf.Sqrt(Acceleration);
                //_velocity += (acceleration - damping) * Time.deltaTime;
            }
        }

        if (Input.GetButton("Fire1"))
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
                    enemy.DoLaserHit(100.0f * Time.deltaTime);
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

    new void FixedUpdate()
    {
        if (Role != CharacterRole.Drone && _rb != null)
        {
            _rb.velocity = _velocity;
        }
    }
}
