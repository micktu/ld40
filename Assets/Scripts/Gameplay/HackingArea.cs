using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingArea : MonoBehaviour {

	private StrategyGame _game;
	private bool _hackable = true;
	private bool _isHacking = false;
    public GameObject terminal;
    public float terminalPrice = 1f;
    public int totalCoins = 100;

	// Use this for initialization
	void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	}
	
	// Update is called once per frame
	void Update () {
        if (_isHacking) {
            if (totalCoins > 0)
            {
                totalCoins--;
            }
            if (totalCoins == 0 && _hackable) {
                terminal.GetComponent<SpriteRenderer>().color = new Color(55, 55, 55);
                stopHacking();
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() == null)
        {
            return;
        }

        if (_hackable) {
            terminal.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            _game.CoinsIncome += terminalPrice;
            _isHacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Character>() == null)
        {
            return;
        }
        terminal.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        stopHacking();
    }

    void stopHacking() {
        if (_hackable) {
            _game.CoinsIncome -= terminalPrice;
            _hackable = false;
            _isHacking = false;
        }
    }
}
