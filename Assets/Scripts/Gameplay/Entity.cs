using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
	private StrategyGame _game;
	private Rigidbody2D _rb;

	protected Vector2 _velocity;
	public float DeadZone = 0.3f;
	public float Acceleration = 50.0f;
	public float Drag = 30.0f;
	public float StopThreshold = 0.1f;
	public float MaxSpeed = 6.0f;

	protected void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	    _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected void Update () {
		if (_rb != null)
		{
			_velocity -= _velocity.normalized * Drag * Time.deltaTime;

			if (_velocity.sqrMagnitude < StopThreshold * StopThreshold)
			{
				_velocity = Vector2.zero;
			}

			if (_velocity.sqrMagnitude > MaxSpeed * MaxSpeed)
			{
				_velocity = Vector2.ClampMagnitude(_velocity, MaxSpeed);
			}
		}
	}

	void FixedUpdate()
	{
		if (_rb != null)
		{
			_rb.velocity = _velocity;
		}
	}
}
