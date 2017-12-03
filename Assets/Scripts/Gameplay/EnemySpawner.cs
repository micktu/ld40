using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	private StrategyGame _game;
    private Coroutine _spawnCoroutine;

    // Use this for initialization
    void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
        _spawnCoroutine = StartCoroutine(SpawnEnemy());
	}

    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            _game.SpawnEnemy(transform.position);
            if (_game.EnergySpent < 50)
            {
                yield return new WaitForSeconds(3.0f);
            }
            else
            if (_game.EnergySpent < 100)
            {
                yield return new WaitForSeconds(2.0f);
            }
            else
            if (_game.EnergySpent < 200)
            {
                yield return new WaitForSeconds(1.0f);
            }
            else
            if (_game.EnergySpent < 250)
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void OnDestroy() {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
	
	// Update is called once per frame
	void Update () {
    }
}
