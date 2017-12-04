using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	private StrategyGame _game;
    private bool _visible = false;

    // Use this for initialization
    void Start () {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
	}

    public void SpawnEnemy(EnemyType enemyType)
    {
        _game.SpawnEnemy(transform.position, enemyType);
    }

    void OnBecameInvisible() {
        _visible = false;
    }

    void OnBecameVisible() {
        _visible = true;
    }

    // Update is called once per frame
    void Update() {
        if (_visible) {
            return;
        }
        int shockers = _game.Enemies.FindAll((x) => x.Type == EnemyType.Shocker).Count;
        int blasters = _game.Enemies.FindAll((x) => x.Type == EnemyType.Blaster).Count;
        if (_game.Alarm == AlarmLevel.Green && shockers < 20) {
            SpawnEnemy(EnemyType.Shocker);
        }

        if (_game.Alarm != AlarmLevel.Green && shockers < 40) {
            SpawnEnemy(EnemyType.Shocker);
        }
        if (_game.Alarm != AlarmLevel.Green && blasters < 1) {
            SpawnEnemy(EnemyType.Blaster);
        }
    }
}
