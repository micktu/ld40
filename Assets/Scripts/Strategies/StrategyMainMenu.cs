using System.Collections.Generic;

public class StrategyMainMenu : StrategyBase
{
    public ScreenTitleScreen TitleScreen;

    private Dictionary<ScreenType, ScreenBase> _screens;
    private ScreenType _activeScreen, _lastScreen;


    protected override void OnInit()
    {
        _screens = new Dictionary<ScreenType, ScreenBase>
        {
            {ScreenType.TitleScreen, TitleScreen},
        };

        foreach (var screen in _screens.Values)
        {
            screen.Init(_manager);
        }
    }

    protected override void OnEnter(StrategyType lastStrategy)
    {
        _screens[_activeScreen].Enter(_lastScreen);

        var gm = GameManager.Instance;
        if (gm.MusicSource.clip != gm.MainMenuClip)
        {
            gm.MusicSource.clip = gm.MainMenuClip;
        }
        gm.MusicSource.Play();
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