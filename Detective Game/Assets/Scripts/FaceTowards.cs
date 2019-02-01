using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTowards : MonoBehaviour
{
    public FollowWaypoints monsterScript;
    public Transform target;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        target = monsterScript.target;

        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotaton = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotaton, speed * Time.deltaTime);
        
    }
}
