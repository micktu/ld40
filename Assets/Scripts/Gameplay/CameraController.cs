using UnityEngine;
using System.Collections;
using EZCameraShake;

public class CameraController : MonoBehaviour
{
	private StrategyGame _game;

    private Vector2 offset;

    private Vector2 _velocity;

    public Vector2 followBounds = new Vector2(4.0f, 2.0f);
    public float FollowSpeed = 3.0f;

    void Start()
    {
        //offset = transform.position - _game.Character.transform.position;
    }

    void Update()
    {
        var game = GameManager.Instance.ActiveStrategy as StrategyGame;


        var camera = Camera.main;
        var halfHeight = camera.orthographicSize;
        var halfWidth = halfHeight * camera.aspect;

        if (game != null)
        {
            var velocity = game.Character.Velocity;

            if (velocity.sqrMagnitude > 0.2f)
            {
                _velocity = velocity.normalized * FollowSpeed;

                offset += _velocity * Time.deltaTime;
                Debug.Log(offset);

                if (offset.x > followBounds.x) offset.x = followBounds.x;
                else if (offset.x < -followBounds.x) offset.x = -followBounds.x;

                if (offset.y > followBounds.y) offset.y = followBounds.y;
                else if (offset.y < -followBounds.y) offset.y = -followBounds.y;
            }

            var position = game.Character.transform.position;
            position.z = -10.0f;

            position += (Vector3)offset;

            if (position.x > 15.0f - halfWidth) position.x = 15.0f - halfWidth;
            else if (position.x < -15.0f + halfWidth) position.x = -15.0f + halfWidth;

            if (position.y > 15.0f - halfHeight) position.y = 15.0f - halfHeight;
            else if (position.y < -15.0f + halfHeight) position.y = -15.0f + halfHeight;

            transform.position = position;
        }
    }
}