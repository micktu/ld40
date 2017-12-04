using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum AlarmLevel {
    Green,
    Orange,
    Red,
    Black
}

public class StrategyGame : StrategyBase
{
	private GameManager _gameManager;

    public PlayerInput PlayerInput;
    public GameObject ContainerHUD;
    public GameObject ExitPad;
    public bool PlayerOnExit = false;

    public AudioSource MusicSource;
    public HUD Hud;

    public Character CharacterPrefab, DronePrefab;
    public Enemy EnemyPrefab;
    public Enemy EnemyShooterPrefab;

    public Character Character, Drone;
    public GameObject Level;

    public float Coins = 0f;
    public int KillCount = 0;
    public int TerminalsCaptured = 0;

    private int _lastEnemyPositionIndex;

    private List<Enemy> _enemies = new List<Enemy>();

    public List<Enemy> Enemies
    {
        get { return _enemies; }
    }

    public int FinalCost = 350;
    public int FinalEnergyCost = 300;
    public Text FinalText;

    // public float HitPointsMax = 100f;
    // public float HitPoints = 100f;
    public float EnergyDamage = 0f;
    public float EnergyMax = 300f;
    public float EnergyDrain = 10f;
    public float EnergyStart = 30f;
    public float Energy = 0f;
    public float EnergyGain = 1f;
    public float EnergySpent = 0f;
    public float EnergyNeedForFire = 5f;
    public float EnergyWhenHacking = 2f;
    public float EnergyRegenStep = 1.0f;
    private Coroutine _spawnCoroutine;

    public float LaserDamage = 100f;
    public AlarmLevel Alarm;

    public HackingArea[] HackingAreas;

    public IEnumerator RegenEnergy()
    {
        while (true)
        {
            Energy += EnergyGain * (1 + EnergyWhenHacking);
            //Debug.Log("Energy regened " + Energy);
            yield return new WaitForSeconds(EnergyRegenStep);
        }
    }

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
        HackingAreas = FindObjectsOfType<HackingArea>();

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
        Alarm = AlarmLevel.Green;
        Level.gameObject.SetActive(true);
        PlayerInput.enabled = true;
        Character.gameObject.SetActive(true);
        Drone.gameObject.SetActive(true);
       
        ContainerHUD.SetActive(true);
        _spawnCoroutine = StartCoroutine(RegenEnergy());

        Energy = EnergyStart;

        var gm = GameManager.Instance;
        if (gm.MusicSource.clip != gm.MusicClip)
        {
            gm.MusicSource.clip = gm.MusicClip;
        }
        gm.MusicSource.Play();
    }

    protected override void OnLeave()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }

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

        MusicSource.Pause();
    }

    public void SpawnEnemy(Vector3 position, EnemyType enemyType)
    {
        if (enemyType == EnemyType.Shocker)
        {
            var enemy = Instantiate(EnemyPrefab, position, Quaternion.identity);
            _enemies.Add(enemy);
        }
        else {
            var enemy = Instantiate(EnemyShooterPrefab, position, Quaternion.identity);
            _enemies.Add(enemy);
        }
    }

    void TakeDamage() {
        float damage = EnergyDamage * Time.deltaTime;
        if (damage == 0) {
            return;
        }
        Energy -= damage;
        Character.OnTakeDamage();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            LeaveLevel(false);
            return;
        }
        if (Energy >= EnergyMax || Energy < 0) {
            if (!Character.IsDead) {
                StartCoroutine(Character.OnDeath());
            }
            return;
        }

        EnemySpawner[] spawners = GameObject.FindObjectsOfType<EnemySpawner>();
        spawners[Random.Range(0, spawners.Length - 1)].UpdateEnemies();
        TakeDamage();

        if (Alarm == AlarmLevel.Green && (TerminalsCaptured > 0 || KillCount >= 2)) {
            Alarm = AlarmLevel.Orange;
        } else 
        if (Alarm == AlarmLevel.Orange && (TerminalsCaptured > 1)) {
            Alarm = AlarmLevel.Red;
        } else 
        if (Alarm == AlarmLevel.Red && (TerminalsCaptured == 3)) {
            Alarm = AlarmLevel.Black;
        }
        String AlarmColor = "";
        switch (Alarm)
        {
            case AlarmLevel.Green:
                AlarmColor = "Green";
                break;
            case AlarmLevel.Orange:
                AlarmColor = "Orange";
                break;
            case AlarmLevel.Red:
                AlarmColor = "Red";
                break;
            case AlarmLevel.Black:
                AlarmColor = "Black";
                break;
            default:
                break;
        }
        Hud.SetCoins((int)Coins, FinalCost);
        Hud.SetEnergy((int)Energy, (int)EnergyMax, (int)EnergyNeedForFire);
        Hud.SetEnergySpent((int)EnergySpent, (int)FinalEnergyCost);
        if (Coins >= FinalCost && EnergySpent >= FinalEnergyCost) {
            FinalText.gameObject.SetActive(true);
            if (PlayerOnExit) {
                Debug.Log(String.Format("Level ended, you won"));
                LeaveLevel(true);
            }
        }
    }

    public void LeaveLevel(bool win)
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }

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

        Coins = 0;
        Energy = 30f;

        if (win)
        {
            _gameManager.EnterWinScreen();
        }
        else {
            _gameManager.EnterLooseScreen();
        }

        Destroy(Level);

        MusicSource.Stop();
    }
}