using UnityEngine;

public class StrategyBase : MonoBehaviour
{
    protected GameManager _manager;

    public void Init(GameManager manager)
    {
        _manager = manager;
        enabled = false;

        OnInit();
    }

    public void Enter(StrategyType lastStrategy)
    {
        enabled = true;

        OnEnter(lastStrategy);
    }

    public void Leave()
    {
        enabled = false;

        OnLeave();
    }

    protected virtual void OnInit()
    {

    }

    protected virtual void OnEnter(StrategyType lastStrategy)
    {

    }

    protected virtual void OnLeave()
    {
        
    }
}
