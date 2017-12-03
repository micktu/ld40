﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public enum ResultType {
    Playing,
    Win,
    Loose
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject Level;
    public ResultType Result;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    private Dictionary<StrategyType, StrategyBase> _strategies;

    private StrategyType _activeStrategy, _lastStrategy;
    private bool _strategyChangePending;

    public Canvas Canvas;

    public StrategyBase ActiveStrategy
    {
        get { return _strategies[_activeStrategy]; }
    }

    void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(FindObjectOfType<Canvas>().gameObject);
        DontDestroyOnLoad(FindObjectOfType<EventSystem>().gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "main") return;

        Level = GameObject.Find("Level");

        var game = _strategies[StrategyType.Game] as StrategyGame;
        game.Level = Level;
        game.InitLevel();
        Enter(StrategyType.Game);
    }

    void OnEnable()
    {
        _strategies = new Dictionary<StrategyType, StrategyBase>
        {
            {StrategyType.MainMenu, GetComponent<StrategyMainMenu>()},
            {StrategyType.Game, GetComponent<StrategyGame>()},
            {StrategyType.ResultScreen, GetComponent<StrategyResultScreen>()},
        };

        foreach (var strategy in _strategies.Values)
        {
            strategy.Init(this);
        }
    }

    void Start()
    {
        //LevelIndex.LoadLevels();

        EnterMainMenu();
        //EnterGame();
    }

    void Update()
    {
        if (_strategyChangePending)
        {
            _strategies[_lastStrategy].Leave();
            _strategies[_activeStrategy].Enter(_lastStrategy);
            _strategyChangePending = false;
        }
    }

    public void Enter(StrategyType strategyType)
    {
        _lastStrategy = _activeStrategy;
        _activeStrategy = strategyType;
        _strategyChangePending = true;
    }

    public void EnterMainMenu()
    {
        Enter(StrategyType.MainMenu);
    }

    public void EnterWinScreen()
    {
        Result = ResultType.Win;
        Enter(StrategyType.ResultScreen);
    }

    public void EnterLooseScreen()
    {
        Result = ResultType.Loose;
        Enter(StrategyType.ResultScreen);
    }

    public void EnterGame()
    {
        Result = ResultType.Playing;
        Enter(StrategyType.Game);
    }

    public void EnterGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
