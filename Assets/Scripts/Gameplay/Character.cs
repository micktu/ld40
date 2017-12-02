using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

public enum CharacterRole
{
    Main,
    Drone
}

public class Character : Entity {

	public Text DebugText;

    public CharacterRole Role;

    private string _hAxis, _vAxis;

    private List<VectorLine> _laserLines = new List<VectorLine>();

    protected new void Start()
    {
        base.Start();

        _hAxis = Role == CharacterRole.Main ? "CharacterHorizontal" : "DroneHorizontal";
        _vAxis = Role == CharacterRole.Main ? "CharacterVertical" : "DroneVertical";

        var points = new List<Vector3>
        {
            Vector3.zero,
            Vector3.zero,
        };
        var line = new VectorLine("Laser1", points, 3.0f);
        _laserLines.Add(line);
    }

    protected new void Update () {
		var axis = new Vector2();

		axis.x = Input.GetAxisRaw(_hAxis);
		axis.y = Input.GetAxisRaw(_vAxis);

        if (Mathf.Abs(axis.x) < DeadZone) axis.x = 0.0f;
		else axis.x = Mathf.Sign(axis.x);

		if (Mathf.Abs(axis.y) < DeadZone) axis.y = 0.0f;
		else axis.y = Mathf.Sign(axis.y);

		_velocity += axis * Acceleration * Time.deltaTime;

		base.Update();


        if (Input.GetButton("Fire1"))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.IntersectXY();

            var position = transform.position;

            var points = _laserLines[0].points3;
            points.Clear();
            points.Add(position);
            var direction = (point - position).normalized;

            int i;
            for (i = 0; i < 10; i++)
            {
                var hit = Physics2D.Raycast(position, direction, 10.0f, 1 << LayerMask.NameToLayer("Geometry"));
                if (hit.collider == null)
                {
                    points.Add(position + direction * 10.0f);
                    break;
                }

                points.Add(hit.point);
                direction = Vector2.Reflect(direction, -hit.normal);
                position = (Vector3)hit.point + direction * 0.1f;
            }

            if (DebugText != null)
            {
                DebugText.text = String.Format("{0}", points.Count);
            }

            _laserLines[0].active = true;
            _laserLines[0].Draw();
        }
        else
        {
            _laserLines[0].active = false;
        }
	}
}
