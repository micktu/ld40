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
            CoinTracker.color = new Color(55, 255, 55);
        }
        else {
            CoinTracker.color = new Color(255,255,255);
        }
    }

    public void SetEnergySpent(int energy, int cost) {
        EnergySpentTracker.text = String.Format("Spent:   {0} // {1}", energy, cost);
        if (energy >= cost)
        {
            EnergySpentTracker.color = new Color(55, 255, 55);
        }
        else
        {
            EnergySpentTracker.color = new Color(255, 255, 255);
        }

    }

    public void SetEnergy(int energy, int max, int min) {
        EnergyTracker.text = String.Format("Energy: {0} // {1}", energy, max);
        if (energy / max >= 0.9 || energy <= min)
        {
            EnergyTracker.color = new Color(255, 25, 25);
        }
        else {
            EnergyTracker.color = new Color(255,255,255);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
