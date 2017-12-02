using UnityEngine;

public class ScreenBase : MonoBehaviour
{
    protected GameManager _manager;

    public void Init(GameManager manager)
    {
        _manager = manager;

        gameObject.SetActive(false);

        OnInit();
    }

    public void Enter(ScreenType lastScreen)
    {
        gameObject.SetActive(true);

        OnEnter(lastScreen);
    }

    public void Leave()
    {
        gameObject.SetActive(false);

        OnLeave();
    }

    protected virtual void OnInit()
    {
        
    }

    protected virtual void OnEnter(ScreenType lastScreen)
    {
        
    }

    protected virtual void OnLeave()
    {
        
    }
}
