using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	private StrategyGame _game;

    // Use this for initialization
    void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	}

    public void SpawnEnemy(EnemyType enemyType)
    {
        _game.SpawnEnemy(transform.position, enemyType);
    }

    // Update is called once per frame
    void Update() {
        if (_game.Alarm == AlarmLevel.Green && _game.Enemies.Count < 6) {
            SpawnEnemy(EnemyType.Shocker);
        }
        else 
        if (_game.Alarm == AlarmLevel.Orange && _game.Enemies.Count < 12) {
            SpawnEnemy(EnemyType.Blaster);
        }
    }
}
