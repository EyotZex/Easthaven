using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float WalkSpeed;
	public float SneakSpeed;
    public float RunSpeed;
	public Rigidbody2D rb;
	public Vector2 moveVelocity;
	public bool playerStill;

    void Start () {
		rb = GetComponent<Rigidbody2D> ();
    }

	void Update () {
		Vector2 moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveInput.normalized * speed;

		if (Input.GetAxisRaw ("Horizontal") == 0 && Input.GetAxisRaw ("Vertical") == 0) {
			playerStill = true;
        } else {
			playerStill = false;

        }

		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = RunSpeed;
        } else if (Input.GetKey(KeyCode.LeftControl)){
            speed = SneakSpeed;
        }
        else{
            speed = WalkSpeed;
        }
    }

	void FixedUpdate(){
		rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);
	}
}
