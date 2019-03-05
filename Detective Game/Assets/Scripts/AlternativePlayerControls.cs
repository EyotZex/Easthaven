using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativePlayerControls : MonoBehaviour
{

    public float speed;
    public float WalkSpeed;
    public float RunSpeed;
    public bool playerStill;
    public bool playerDied;

    public Rigidbody2D rb;
    public DoubleClickDetect doubleclickDetectScript;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = WalkSpeed;
    }


    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
    void FixedUpdate()
    {
        if (!playerDied)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    speed = RunSpeed;
                }
                else
                {
                    speed = WalkSpeed;
                }
                rb.velocity = transform.right * speed;
                playerStill = false;
            }
            else
            {
                rb.velocity = transform.right * 0;
                playerStill = true;
            }
        }
    }
}
