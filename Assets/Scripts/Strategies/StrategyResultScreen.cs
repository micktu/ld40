using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategyResultScreen : StrategyBase
{
    public ResultScreen ResultScreen;
    public Text ResultText;

    private Dictionary<ScreenType, ScreenBase> _screens;
    private ScreenType _activeScreen, _lastScreen;


    protected override void OnInit()
    {
        _screens = new Dictionary<ScreenType, ScreenBase>
        {
            {ScreenType.TitleScreen, ResultScreen},
        };

        foreach (var screen in _screens.Values)
        {
            screen.Init(_manager);
        }
    }

    protected override void OnEnter(StrategyType lastStrategy)
    {
        _screens[_activeScreen].Enter(_lastScreen);
        if (GameManager.Instance.Result == ResultType.Win)
        {
            ResultText.text = "Info(): Compiled successfully";
            ResultText.color = new Color(55f/255f, 255f/255f, 55f/255f);

            var gm = GameManager.Instance;
            if (gm.MusicSource.clip != gm.WinClip)
            {
                gm.MusicSource.loop = false;
                gm.MusicSource.clip = gm.WinClip;
            }
            gm.MusicSource.Play();
        }
        else {
            ResultText.text = "Error(): Connection Lost";
            ResultText.color = new Color(255f/255f, 55f/255f, 55f/255f);

            var gm = GameManager.Instance;
            if (gm.MusicSource.clip != gm.LoseClip)
            {
                gm.MusicSource.loop = false;
                gm.MusicSource.clip = gm.LoseClip;
            }
            gm.MusicSource.Play();
        }
    }

    protected override void OnLeave()
    {
        _screens[_activeScreen].Leave();
    }

    private void Enter(ScreenType screenType)
    {
        _screens[_activeScreen].Leave();
        _lastScreen = _activeScreen;
        _activeScreen = screenType;
        _manager.EnterMainMenu();
    }

    public void EnterTitleScreen()
    {
        Enter(ScreenType.TitleScreen);
    }
}
