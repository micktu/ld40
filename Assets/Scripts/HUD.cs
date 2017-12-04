using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public Text CoinTracker;
    public Text EnergyTracker;
    public Text EnergySpentTracker;

    public void SetCoins(int coins, int cost) {
        CoinTracker.text = String.Format("Coins:   {0} // {1}", coins, cost);
        if (coins >= cost)
        {
            CoinTracker.color = new Color(55f/255f, 1f, 55f/255f);
        }
        else {
            CoinTracker.color = new Color(1f,1f,1f);
        }
    }

    public void SetEnergySpent(int energy, int cost) {
        EnergySpentTracker.text = String.Format("Spent:   {0} // {1}", energy, cost);
        if (energy >= cost)
        {
            EnergySpentTracker.color = new Color(55f/255f, 255f/255f, 55f/255f);
        }
        else
        {
            EnergySpentTracker.color = new Color(1f,1f,1f);
        }

    }

    public void SetEnergy(int energy, int max, int min) {
        EnergyTracker.text = String.Format("Energy: {0} // {1}", energy, max);
        if (energy / max >= 0.9 || energy <= min)
        {
            EnergyTracker.color = new Color(255f/255f, 25f/255f, 25f/255f);
        }
        else {
            EnergyTracker.color = new Color(1f,1f,1f);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
