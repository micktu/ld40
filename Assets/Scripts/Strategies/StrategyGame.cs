using UnityEngine;

public class StrategyGame : StrategyBase
{
    //public PlayerInput PlayerInput;
    public GameObject ContainerHUD;

    protected override void OnInit()
    {
        // Level.gameObject.SetActive(false);
        // PlayerInput.gameObject.SetActive(false);
        // ContainerHUD.SetActive(false);

        var camera = Camera.main;
        var halfHeight = camera.orthographicSize;
        var halfWidth = halfHeight * camera.aspect;
    }

    protected override void OnEnter(StrategyType lastStrategy)
    {
        // Level.gameObject.SetActive(true);
        // PlayerInput.gameObject.SetActive(true);
        // ContainerHUD.SetActive(true);
    }

    protected override void OnLeave()
    {
        // Level.gameObject.SetActive(false);
        // PlayerInput.gameObject.SetActive(false);
        // ContainerHUD.SetActive(false);
    }

    void Update()
    {
    }
}