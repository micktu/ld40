using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;
using DG.Tweening;
using EZCameraShake;

public enum CharacterRole
{
    Main,
    Drone
}

public class Character : Entity {

	public Text DebugText;

    public CharacterRole Role;

    public Material LaserMaterial;

    public GameObject LaserPrefab;

    private GameObject _laserParticles;

    private AudioSource[] _as;

    private string _hAxis, _vAxis;
    private bool _playDamage = false;

    public Vector3 Destination;
    private bool _isAtDestination;
    private bool _isSearchingPath;

    private List<VectorLine> _laserLines = new List<VectorLine>();

    private int _laserLayerMask;
    private SpriteRenderer _renderer;

    private Coroutine _soundCoroutine;

    private Seeker _seeker;
    public bool IsDead;

    private PathInterpolator _interpolator = new PathInterpolator();
    private ABPath _path;
    private IMovementPlane _movementPlane;
    public ParticleSystem ExplosionParticle;

    IEnumerator _soundTimeout() {
        yield return new WaitForSeconds(1.66f);
        _playDamage = false;
    }

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
        var line = new VectorLine("Laser1", points, 20.0f, LineType.Continuous, Joins.Weld);
        line.material = LaserMaterial;
        line.textureScale = 4.0f;
        line.useViewportCoords = true;
        //line.SetColor(new Color32(10, 10, 200, 255));
        _laserLines.Add(line);

        _laserParticles = Instantiate(LaserPrefab);
        _laserParticles.SetActive(false);

        _as = GetComponents<AudioSource>();

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
                Velocity += direction * Acceleration * Time.deltaTime;
            }
            else
            {
                if (!_interpolator.valid || _isAtDestination)
                {
                    Velocity = Vector3.zero;
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
                       AddSpringForce(dir, distance);
                    }
                }
            }
        }

        if (Input.GetButton("Fire1") && _game.Energy >=_game.EnergyNeedForFire)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.IntersectXY();

            var position = transform.position;

            var direction = (point - position).normalized;
            position += direction * 0.32f;

            var points = _laserLines[0].points3;
            points.Clear();
            points.Add(position);
            
            for (var i = 0; i < 2; i++)
            {
                var hit = Physics2D.Raycast(position, direction, 10.0f, _laserLayerMask);
                if (hit.collider == null)
                {
                    points.Add(position + direction * 10.0f);
                    break;
                }

                points.Add(hit.point);

                var enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.DoLaserHit(_game.LaserDamage * Time.deltaTime);
                    float ed = _game.EnergyDrain * Time.deltaTime;
                    if (_game.Energy >= ed && ed >= 0)
                    {
                        _game.Energy -= ed;
                        _game.EnergySpent += ed;
                    }
                    else
                    {
                        _game.Energy = 0;
                    }
                    break;
                }

                direction = Vector2.Reflect(direction, hit.normal);
                position = (Vector3)hit.point + direction * 0.05f;
            }

            //var laserPosition = position;
            //laserPosition.z -= 5.0f;
            //_laserParticles.transform.position = laserPosition;
            //var rotDir = new Vector3(-direction.y, direction.x);
            //_laserParticles.transform.rotation =
            //    Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            //var scale = Vector3.one * 0.08f;
            //scale.x = Vector3.Distance(point, position) * scale.x;
            //_laserParticles.transform.localScale = scale;

            //_laserParticles.SetActive(true);

            _laserLines[0].active = true;
            _laserLines[0].Draw();

            if (_as.Length > 0 && _as[0].clip != GameManager.Instance.LaserStartClip)
            {
                _as[0].clip = GameManager.Instance.LaserStartClip;
                _as[0].Play();

                _as[1].clip = GameManager.Instance.LaserShotClip;
                _as[1].Play();
            }
        }
        else
        {
            if (_as.Length > 0 && _as[0].clip != GameManager.Instance.LaserEndClip)
            {
                _as[0].clip = GameManager.Instance.LaserEndClip;
                _as[0].Play();

                _as[1].Stop();
            }

            _laserLines[0].active = false;
            //_laserParticles.SetActive(false);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && enemy.Type == EnemyType.Shocker) {
            _game.EnergyDamage += enemy.Damage;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && enemy.Type == EnemyType.Shocker) {
            _game.EnergyDamage -= enemy.Damage;
        }
    }

    public void OnTakeDamage()
    {
        if (_playDamage) {
            return;
        }
        _playDamage = true;
        _as[1].clip = GameManager.Instance.DamageReceive[UnityEngine.Random.Range(0, GameManager.Instance.DamageReceive.Count)];
        _as[1].loop = false;
        _as[1].Play();
        StartCoroutine(_soundTimeout());
    }

    public IEnumerator OnDeath()
    {
        transform.localScale = Vector3.zero;
        IsDead = true;
        //_renderer.material.DOFade(0.0f, 5.0f);

        _playDamage = true;
        _as[1].clip = GameManager.Instance.DeathClip;
        _as[1].Play();

        var particlePosition = transform.position;
        particlePosition.z = -5.0f;
        Instantiate(ExplosionParticle, particlePosition, Quaternion.identity);

        var shaker = CameraShaker.Instance;
        shaker.DefaultPosInfluence = new Vector3(0.25f, 0.25f, 0.0f);
        shaker.DefaultRotInfluence = new Vector3(0.0f, 0.0f, 0.25f);
        shaker.ShakeOnce(4.0f, 7.0f, 0.1f, 0.6f);
        yield return new WaitForSeconds(3f);
        _game.LeaveLevel(false);
    }
}
