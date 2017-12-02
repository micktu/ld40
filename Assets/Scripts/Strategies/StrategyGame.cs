﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategyGame : StrategyBase
{
	private GameManager _gameManager;

    public PlayerInput PlayerInput;
    public GameObject ContainerHUD;
    public GameObject ExitPad;
    public bool PlayerOnExit = false;

    public Text DebugText;

    public Character CharacterPrefab, DronePrefab;
    public Enemy EnemyPrefab;

    public Character Character, Drone;
    public GameObject Level;

    public int Coins = 0;
    public float CoinsIncome = 0f;

    private int _lastEnemyPositionIndex;

    private Coroutine _spawnCoroutine;

    private List<Enemy> _enemies = new List<Enemy>();

    public List<Enemy> Enemies
    {
        get { return _enemies; }
    }

    public int FinalCost = 300;
    public Text FinalText;


    protected override void OnInit()
    {
	    _gameManager = GameManager.Instance;

        //Level.gameObject.SetActive(false);
        PlayerInput.Init();
        PlayerInput.enabled = false;
        ContainerHUD.SetActive(false);
        FinalText.gameObject.SetActive(false);

        var camera = Camera.main;
        var halfHeight = camera.orthographicSize;
        var halfWidth = halfHeight * camera.aspect;
    }

    public void InitLevel()
    {
        if (Character != null)
        {
            Destroy(Character.gameObject);
        }

        if (Drone != null)
        {
            Destroy(Drone.gameObject);
        }

        foreach (var enemy in Enemies)
        {
            Destroy(enemy.gameObject);
        }
        Enemies.Clear();

        Character = Instantiate(CharacterPrefab, Vector3.zero, Quaternion.identity);
        Character.gameObject.SetActive(false);
        Character.Role = CharacterRole.Main;
        Character.DebugText = DebugText;

        Drone = Instantiate(DronePrefab, Vector3.zero, Quaternion.identity);
        Drone.gameObject.SetActive(false);
        Drone.Role = CharacterRole.Drone;
    }

    protected override void OnEnter(StrategyType lastStrategy)
    {
        Level.gameObject.SetActive(true);
        PlayerInput.enabled = true;
        Character.gameObject.SetActive(true);
        Drone.gameObject.SetActive(true);
       
        ContainerHUD.SetActive(true);

        _spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    protected override void OnLeave()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }

        //Level.gameObject.SetActive(false);
        PlayerInput.enabled = false;
        Character.gameObject.SetActive(false);
        Drone.gameObject.SetActive(false);
        ContainerHUD.SetActive(false);
    }

    IEnumerator SpawnEnemies()
    {
        var positions = new List<Vector3>
        {
            new Vector3(0.0f, 0.0f),
            new Vector3(4.0f, 0.0f),
            new Vector3(0.0f, 4.0f),
            new Vector3(4.0f, 4.0f),
        };

        while (true)
        {
            var index = (_lastEnemyPositionIndex + 1 + Random.Range(0, positions.Count - 1)) % positions.Count;
            _lastEnemyPositionIndex = index;
            var position = positions[index];
            var enemy = Instantiate(EnemyPrefab, position, Quaternion.identity);
            _enemies.Add(enemy);
            yield return new WaitForSeconds(3.0f);
        }
    }

    void Update()
    {
        Coins += (int) CoinsIncome;
        if (Coins >= FinalCost) {
            FinalText.gameObject.SetActive(true);
            ExitPad.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            if (PlayerOnExit) {
                _gameManager.EnterMainMenu();
            }
        }
    }
}