using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

	public float scaleSpeed = 3f;
	Vector3 temp; 
		
	void Start () {
		Destroy (gameObject, 2.0f);
	}
	

	void Update () {
		temp = transform.localScale;
		temp.x += Time.deltaTime;
		temp.y += Time.deltaTime;
		transform.localScale = temp;
	}
}
