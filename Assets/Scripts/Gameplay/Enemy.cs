﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

	new void Start ()
	{
	    base.Start();
	}
	
	new void Update ()
	{
	    var direction = (_game.Character.transform.position - transform.position).normalized;

	    _velocity += (Vector2)direction * Acceleration * Time.deltaTime;

        transform.localScale = Vector3.one * (0.5f + CurrentEnergy / MaxEnergy);

        base.Update();
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
    }

    public override void DoLaserHit(float energy)
    {
        AddEnergy(energy);
    }
}