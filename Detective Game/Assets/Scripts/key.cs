using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

	public DoorControl doorScript;
    private bool CanBeInteracted;

    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && CanBeInteracted)
        {
            print("key");
            doorScript.hasKey = true;
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = true;
        }
    }
    

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = false;
        }
    }
}
