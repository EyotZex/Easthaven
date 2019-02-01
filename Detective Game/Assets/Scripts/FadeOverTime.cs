using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOverTime : MonoBehaviour {

	public float alphaLevel = 1.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		alphaLevel -= 0.008f;
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alphaLevel);
	}
}
