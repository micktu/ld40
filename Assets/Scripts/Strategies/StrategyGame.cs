using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StrategyGame : StrategyBase
{
	private GameManager _gameManager;

    public PlayerInput PlayerInput;
    public GameObject ContainerHUD;
    public GameObject ExitPad;
    public bool PlayerOnExit = false;

    public Text CoinsText;

    public Character CharacterPrefab, DronePrefab;
    public Enemy EnemyPrefab;

    public Character Character, Drone;
    public GameObject Level;

    public int Coins = 0;
    public float CoinsIncome = 0f;

    private int _lastEnemyPositionIndex;

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
        Drone = Instantiate(DronePrefab, Vector3.zero, Quaternion.identity);
        Drone.gameObject.SetActive(false);
        Drone.Role = CharacterRole.Drone;

        Character = Instantiate(CharacterPrefab, Vector3.zero, Quaternion.identity);
        Character.gameObject.SetActive(false);
        Character.Role = CharacterRole.Main;
        //Character.DebugText = DebugText;

        ExitPad = Level.transform.Find("Exit").gameObject;
    }

    protected override void OnEnter(StrategyType lastStrategy)
    {
        Level.gameObject.SetActive(true);
        PlayerInput.enabled = true;
        Character.gameObject.SetActive(true);
        Drone.gameObject.SetActive(true);
       
        ContainerHUD.SetActive(true);
    }

    protected override void OnLeave()
    {
        if (Level != null)
        { 
            Level.gameObject.SetActive(false);
        }

        if (Character != null)
        {
            Character.gameObject.SetActive(false);
            Drone.gameObject.SetActive(false);
        }

        ContainerHUD.SetActive(false);
        PlayerInput.enabled = false;
    }

    public void SpawnEnemy(Vector3 position)
    {
            var enemy = Instantiate(EnemyPrefab, position, Quaternion.identity);
            _enemies.Add(enemy);
    }

    void Update()
    {
        Coins += (int) CoinsIncome;
        CoinsText.text = String.Format("Coins: {0}\nIncome: {1}", Coins, CoinsIncome);
        if (Coins >= FinalCost) {
            FinalText.gameObject.SetActive(true);
            ExitPad.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            if (PlayerOnExit) {
                LeaveLevel();
            }
        }
    }

    void LeaveLevel()
    {
        Coins = 0;
        CoinsIncome = 0.0f;

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

        EnemySpawner[] spawners = GameObject.FindObjectsOfType<EnemySpawner>();
        foreach (var spawner in spawners)
        {
            Destroy(spawner.gameObject);
        }


        _gameManager.EnterMainMenu();

        Destroy(Level);
    }
}