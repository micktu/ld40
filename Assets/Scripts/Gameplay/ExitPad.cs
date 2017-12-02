using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPad : MonoBehaviour {
	private StrategyGame _game;

	// Use this for initialization
	void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() != null) {
           _game.PlayerOnExit = true;
        }
    }
}
