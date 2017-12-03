using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	private StrategyGame _game;

    private Vector3 offset;

    void Start()
    {
        //offset = transform.position - _game.Character.transform.position;
    }

    void LateUpdate()
    {
        var game = GameManager.Instance.ActiveStrategy as StrategyGame;

        if (game != null)
        {
            var position = game.Character.transform.position;
            position.z = -10.0f;
            transform.position = position;
        }
    }
}