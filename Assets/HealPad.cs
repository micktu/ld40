using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPad : MonoBehaviour {
    private Character _hacker;
	private StrategyGame _game;

	// Use this for initialization
	void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	}
	
	// Update is called once per frame
	void Update () {
        if (_hacker != null) {
            _game.Energy += Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        _hacker = other.GetComponent<Character>();
        if (_hacker == null || _hacker.Role != CharacterRole.Main)
        {
            _hacker = null;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (_hacker != other.GetComponent<Character>())
        {
            return;
        }
        _hacker = null;
    }
}
