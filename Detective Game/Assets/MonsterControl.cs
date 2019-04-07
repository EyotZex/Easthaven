using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    public Admin admin;
    public float monsterSpeed = 0.5f;
    public float monsterChaseSpeed = 1.5f;
    private float directionToGo;
    private float currentFacing;

    private float roamTimer;
    private float roamTimerStart = 5;
    private float ReturnToRoamTimer;
    private float ReturnToRoamTimerStart = 5;

    public Transform target;
    private Vector3 targetPos;

    void Start()
    {
        admin = GameObject.FindGameObjectWithTag("Admin").GetComponent<Admin>();
    }

    void Update()
    {
        currentFacing = transform.eulerAngles.z;
        roamTimer -= Time.deltaTime;
        ReturnToRoamTimer -= Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, directionToGo);
        transform.Translate(Vector2.up * Time.deltaTime * monsterSpeed);

        if (ReturnToRoamTimer > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, monsterChaseSpeed * Time.deltaTime);
        }
        else if (roamTimer <= 0)
        {
            directionToGo = Random.Range(currentFacing - 90, currentFacing + 90);
            roamTimer = roamTimerStart;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sound")
        {
            target = other.gameObject.transform;
            targetPos = target.position;
            ReturnToRoamTimer = ReturnToRoamTimerStart;
        }
        if (other.gameObject.tag == "Wall")
        {
            directionToGo = Random.Range(currentFacing - 240, currentFacing - 90);
            roamTimer = roamTimerStart;
        }
        if (other.gameObject.tag == "Player")
        {
            admin.PlayerDead = true;
        }
    }
}
