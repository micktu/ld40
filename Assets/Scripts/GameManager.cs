using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject Level;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    private Dictionary<StrategyType, StrategyBase> _strategies;

    private StrategyType _activeStrategy, _lastStrategy;
    private bool _strategyChangePending;

    public StrategyBase ActiveStrategy
    {
        get { return _strategies[_activeStrategy]; }
    }

    void Awake()
    {
        _instance = this;
    }

    void OnEnable()
    {
        _strategies = new Dictionary<StrategyType, StrategyBase>
        {
            {StrategyType.MainMenu, GetComponent<StrategyMainMenu>()},
            {StrategyType.Game, GetComponent<StrategyGame>()},
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

    public void EnterGame()
    {
        Enter(StrategyType.Game);
    }

    public void EnterGame(string levelName)
    {
        //var game = _strategies[StrategyType.Game] as StrategyGame;
        //game.Level.Init(LevelIndex.Levels[levelName]);
        Enter(StrategyType.Game);
    }
}
