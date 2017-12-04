using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingArea : MonoBehaviour {

    public Sprite NormalSprite;
    public Sprite ActiveSprite;
    public Sprite BrokenSprite;

	private StrategyGame _game;
	private bool _hackable = true;
	private bool _isHacking = false;
    public GameObject terminal;
    public float terminalPrice = 20f;
    public float totalCoins = 100f;
    private Coroutine _spawnCoroutine;
    private Character _hacker;

    private AudioSource _as;

	// Use this for initialization
	void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	    _as = terminal.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	IEnumerator EarnCoins () {
        while (totalCoins > 0 && _isHacking)
        {
            if (totalCoins >= terminalPrice) {
                totalCoins -= terminalPrice;
            } else {
                totalCoins = 0;
            }
            _game.Coins += terminalPrice;
            yield return new WaitForSeconds(1.0f);
        }
        if (_isHacking) {
            terminal.GetComponent<SpriteRenderer>().sprite = BrokenSprite;

            _as.clip = GameManager.Instance.HackEndClip;
            _as.loop = false;
            _as.Play();
        }
        _stopHacking();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        _hacker = other.GetComponent<Character>();
        if (_hacker == null)
        {
            return;
        }

        if (_hackable) {
            Debug.Log("Start hacking");
            _isHacking = true;
            terminal.GetComponent<SpriteRenderer>().sprite = ActiveSprite;
            _spawnCoroutine = StartCoroutine(EarnCoins());

            _as.clip = GameManager.Instance.HackClip;
            _as.loop = true;
            _as.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (_hacker != other.GetComponent<Character>())
        {
            return;
        }
        if (_hackable)
        {
            terminal.GetComponent<SpriteRenderer>().sprite = NormalSprite;
        }
        else {
            terminal.GetComponent<SpriteRenderer>().sprite = BrokenSprite;
        }
        _stopHacking();
    }

    void _stopHacking() {
        if (_spawnCoroutine != null && _isHacking) {
            Debug.Log("Stop hacking");
            StopCoroutine(_spawnCoroutine);
            _isHacking = false;
            _hacker = null;
            if (totalCoins == 0) {
                _hackable = false;
                _game.TerminalsCaptured++;
            }

            if (_as.clip == GameManager.Instance.HackClip)
            {
                _as.Stop();
            }
        }
    }

    void OnDestroy() {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}
