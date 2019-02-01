using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

	public DoorControl doorScript;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			print ("key");
			doorScript.hasKey = true;
			Destroy(gameObject);
		}
	}
}
