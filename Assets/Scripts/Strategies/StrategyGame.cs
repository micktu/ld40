using UnityEngine;
using UnityEngine.UI;

public class StrategyGame : StrategyBase
{
    public PlayerInput PlayerInput;
    public GameObject ContainerHUD;

    public Text DebugText;

    public Character CharacterPrefab, DronePrefab;

    public Character Character, Drone;
    public GameObject Level;

    public int Coins = 0;
    public float CoinsIncome = 0f;

    protected override void OnInit()
    {
        Level.gameObject.SetActive(false);
        PlayerInput.Init();
        PlayerInput.enabled = false;
        ContainerHUD.SetActive(false);

        Character = Instantiate(CharacterPrefab, Vector3.zero, Quaternion.identity);
        Character.gameObject.SetActive(false);
        Character.Role = CharacterRole.Main;
        Character.DebugText = DebugText;

        Drone = Instantiate(DronePrefab, Vector3.zero, Quaternion.identity);
        Drone.gameObject.SetActive(false);
        Drone.Role = CharacterRole.Drone;

        var camera = Camera.main;
        var halfHeight = camera.orthographicSize;
        var halfWidth = halfHeight * camera.aspect;
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
        Level.gameObject.SetActive(false);
        PlayerInput.enabled = false;
        Character.gameObject.SetActive(false);
        Drone.gameObject.SetActive(false);
        ContainerHUD.SetActive(false);
    }

    void Update()
    {
        Coins += (int) CoinsIncome;
    }
}