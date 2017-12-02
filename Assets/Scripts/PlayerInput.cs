using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
	private DirectionalInput _playerCursor;

	private Direction _directionCharacter;

	public Direction DirectionCharacter
	{
		get { return _directionCharacter; }
	}

	public void Init()
	{
		_playerCursor = new DirectionalInput();
	}

	void Update()
	{
		var axisCharacter = new Vector2();

		axisCharacter.x = Input.GetAxisRaw("CharacterHorizontal");
		axisCharacter.y = Input.GetAxisRaw("CharacterVertical");

		_directionCharacter = _playerCursor.GetDirection(axisCharacter);
	}
}
