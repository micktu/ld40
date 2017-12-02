using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Flags]
public enum Direction : byte
{
	None = 0,
	Up = 1,
	Left = 2,
	Down = 4,
	Right = 8,
}

public class DirectionalInput
{
	private Direction _lastDirMask;
	private Direction _lastInput;

	public Direction GetDirection(Vector2 movement)
	{
		Direction dirMask = Direction.None;

		if (Mathf.Abs(movement.x) > 0.5f)
		{
			dirMask |= movement.x > 0.0f ? Direction.Right : Direction.Left;
		}

		if (Mathf.Abs(movement.y) > 0.5f)
		{
			dirMask |= movement.y > 0.0f ? Direction.Up : Direction.Down;
		}

		Direction diff = dirMask ^ _lastDirMask;
		Direction newInput = _lastInput;

		for (int i = 0; i < 4; i++)
		{
			int flag = 1 << i;
			bool isButtonChanged = ((int)diff & flag) != 0;
			bool isButtonPressed = ((int)dirMask & flag) != 0;
			Direction currentInput = (Direction)i;

			if (isButtonPressed)
			{
				if (isButtonChanged || newInput == Direction.None)
				{
					newInput = currentInput;
				}
			}
			else if (isButtonChanged && currentInput == newInput)
			{
				newInput = Direction.None;
			}
		}

		_lastDirMask = dirMask;
		_lastInput = newInput;

		return newInput;
	}
}
