using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTracker : MonoBehaviour {
	private StrategyGame _game;

	// Use this for initialization
	void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Coins: " + _game.Coins;
        GetComponent<Text>().text += "\nIncome: " + _game.CoinsIncome;
	}
}
