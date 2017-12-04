using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtManager : MonoBehaviour {

    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        SetHealth(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Setting health for the unit. Value 0-1
    /// </summary>
    public void SetHealth(float health)
    {
        health = Mathf.Clamp(health, 0f, 1f);
        Debug.Log(health);
        rend.material.SetFloat("_health", health);
    }
}
