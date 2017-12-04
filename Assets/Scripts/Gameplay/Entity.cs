using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
	protected StrategyGame _game;
	protected Rigidbody2D _rb;

    public HealtManager HealthManager;

	protected Vector2 _velocity;
	public float DeadZone = 0.3f;
	public float Acceleration = 50.0f;
	public float Drag = 30.0f;
	public float StopThreshold = 0.1f;
	public float MaxSpeed = 6.0f;

    public float MaxEnergy = 100.0f;
    public float EnergyDrain = 20.0f;
    private float _lastEnergy;
    private float _currentEnergy;

    private float _lastOrientation;

    public Sprite SpriteFront, SpriteLeft;
    private SpriteRenderer _renderer;

    private Transform _spriteTransform;
    private Animator _animator;

    public bool FlipX, FlipY;

    public float CurrentEnergy
    {
        get { return _currentEnergy; }
    }

    public Vector2 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }

    //public event Action OnEnergyDepleted;
    //public event Action OnMaxEnergyReached;

    protected void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	    _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();

        if (_renderer == null)
        {
            _renderer = transform.GetComponentInChildren<SpriteRenderer>();
            _renderer = transform.GetComponentInChildren<SpriteRenderer>();
        }

        if (transform.childCount > 0)
        {
            _spriteTransform = transform.GetChild(0);
        }
        else
        {
            _animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    protected void Update () {
        _lastEnergy = CurrentEnergy;
        AddEnergy(-EnergyDrain * Time.deltaTime);
    }

	void FixedUpdate()
	{
	    if (_rb != null)
	    {
	        _velocity -= _velocity.normalized * Drag * Time.deltaTime;

	        if (_velocity.sqrMagnitude < StopThreshold * StopThreshold)
	        {
	            _velocity = Vector2.zero;
	        }
	        //else if (_renderer != null)
	        //{
	        //    var scale = _renderer.transform.localScale;

	        //    if (SpriteLeft != null && Mathf.Abs(_velocity.x) >= Mathf.Abs(_velocity.y))
	        //    {
	        //        _renderer.sprite = SpriteLeft;
	        //        scale.x = -Mathf.Sign(_velocity.x) * Mathf.Abs(scale.x);
         //       }
         //       else if (SpriteFront != null)
	        //    {
	        //        _renderer.sprite = SpriteFront;
	        //        scale.y = -Mathf.Sign(_velocity.y) * Mathf.Abs(scale.y);
         //       }

         //       _renderer.transform.localScale = scale;
         //   }

            if (_velocity.sqrMagnitude > MaxSpeed * MaxSpeed)
	        {
	            _velocity = Vector2.ClampMagnitude(_velocity, MaxSpeed);
	        }

            _rb.velocity = _velocity;

	        if (_velocity.sqrMagnitude > 1.0f && _animator == null)
	        {
	            var newOrientation = Mathf.Atan2(_velocity.x, -_velocity.y) * Mathf.Rad2Deg;
	            newOrientation = Mathf.Lerp(_lastOrientation, newOrientation, 0.5f);
	            _lastOrientation = newOrientation;

	            var rotation = Quaternion.Euler(0.0f, 0.0f, newOrientation);
	            if (_spriteTransform)
	            {
	                _spriteTransform.rotation = rotation;
	            }
	            else
	            {
	                transform.rotation = rotation;
	            }
	        }

	        if (_animator != null)
	        {
	            if (_velocity.sqrMagnitude > 0.5f * 0.5f)
	            {
	                _animator.SetBool("IsRunning", true);

	                var scale = _renderer.transform.localScale;
	                scale.x = Mathf.Sign(_velocity.x) * Mathf.Abs(scale.x);
	                _renderer.transform.localScale = scale;
                }
                else
	            {
	                _animator.SetBool("IsRunning", false);
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
    }

    void OnTriggerExit2D(Collider2D other)
    {
    }

    public void AddEnergy(float amount)
    {
        _currentEnergy += amount;

        _currentEnergy = Mathf.Clamp(_currentEnergy, 0, MaxEnergy);

        if (_currentEnergy != _lastEnergy)
        {
            if (_currentEnergy < Mathf.Epsilon)
            {
                OnEnergyDepleted();
            }
            else if (_currentEnergy >= MaxEnergy)
            {
                OnMaxEnergyReached();
            }
        }
    }

    public void AddSpringForce(Vector2 direction, float distance)
    {
        var acceleration = Acceleration * direction.normalized * distance;
        var damping = Velocity * 2.0f * Mathf.Sqrt(Acceleration);
        Velocity += (acceleration - damping) * Time.deltaTime;
    }

    protected virtual void OnEnergyDepleted()
    {
        
    }

    protected virtual void OnMaxEnergyReached()
    {
        
    }

    public virtual void DoLaserHit(float energy)
    {
        
    }
}
