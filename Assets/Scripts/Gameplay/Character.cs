using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterRole
{
    Main,
    Drone
}

public class Character : Entity {

	public Text DebugText;

    public CharacterRole Role;

    private string _hAxis, _vAxis;

    protected new void Start()
    {
        base.Start();

        _hAxis = Role == CharacterRole.Main ? "CharacterHorizontal" : "DroneHorizontal";
        _vAxis = Role == CharacterRole.Main ? "CharacterVertical" : "DroneVertical";
    }

    protected new void Update () {
		var axis = new Vector2();

		axis.x = Input.GetAxisRaw(_hAxis);
		axis.y = Input.GetAxisRaw(_vAxis);

		//DebugText.text = axis.ToString();

		if (Mathf.Abs(axis.x) < DeadZone) axis.x = 0.0f;
		else axis.x = Mathf.Sign(axis.x);

		if (Mathf.Abs(axis.y) < DeadZone) axis.y = 0.0f;
		else axis.y = Mathf.Sign(axis.y);

		_velocity += axis * Acceleration * Time.deltaTime;

		base.Update();
	}
}
