﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum EnemyType
{
    Shocker,
    Blaster,
}

public class Enemy : Entity
{
    public EnemyType Type;
    public float Damage = 5f;

	new void Start ()
	{
	    base.Start();
        Type = EnemyType.Shocker;

        var aiPath = GetComponent<AIPath>();
	    aiPath.target = _game.Character.transform;
	}

    new void Update ()
	{
	    //var direction = (_game.Character.transform.position - transform.position).normalized;

	    //_velocity += (Vector2)direction * Acceleration * Time.deltaTime;

        transform.localScale = Vector3.one * (0.5f + CurrentEnergy / MaxEnergy);

        //base.Update();
	}

    new void FixedUpdate()
    {
        
    }

    protected override void OnEnergyDepleted()
    {
        Debug.Log(string.Format("Depleted, Current Energy: {0}", CurrentEnergy));
    }

    protected override void OnMaxEnergyReached()
    {
        Debug.Log(string.Format("Max, Current Energy: {0}", CurrentEnergy));
        _game.Enemies.Remove(this);
        Destroy(gameObject);
        _game.KillCount++;
    }

    public override void DoLaserHit(float energy)
    {
        AddEnergy(energy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }
    void OnTriggerExit2D(Collider2D other)
    {
    }
}
