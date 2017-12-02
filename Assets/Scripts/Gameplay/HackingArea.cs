using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingArea : MonoBehaviour {

    public GameObject terminal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hacking started");
        terminal.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Hacking stopped");
        terminal.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
}
