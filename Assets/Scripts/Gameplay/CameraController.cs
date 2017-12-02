using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	private StrategyGame _game;

    private Vector3 offset;

    void Start()
    {
	    _game = GameManager.Instance.ActiveStrategy as StrategyGame;
        offset = transform.position - _game.Character.transform.position;
    }

    void LateUpdate()
    {
        transform.position = _game.Character.transform.position + offset;
    }
}