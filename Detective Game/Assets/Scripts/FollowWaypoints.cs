using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{

    public float speed;
    public float chaseSpeed;
    private float waitTime;
    public float startWaitTime;
    public float soundTimer;
    public float soundTimerStart;
    public Transform target;
    private Vector3 targetPos;

    public Transform[] moveSpots;
    private int randomSpot;

    public AudioSource monsterAudioSource;
    public AudioClip momonsterChasing;
    public AudioClip monsterRoar;
    public bool monsterSound;
    public float monsterSoundTimer;
    public float monsterSoundTimerStart;

    public float wayponitTimer;
    public float wayponitTimerStart = 5f;



    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        monsterAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        monsterSoundTimer -= Time.deltaTime;
        soundTimer -= Time.deltaTime;
        wayponitTimer -= Time.deltaTime;

        if (wayponitTimer < 0)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            wayponitTimer = wayponitTimerStart;
        }

        if (soundTimer > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, chaseSpeed * Time.deltaTime);
        }
        else
        {
            target = moveSpots[randomSpot];

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    wayponitTimer = wayponitTimerStart;
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sound")
        {
            target = other.gameObject.transform;
            targetPos = target.position;
            soundTimer = soundTimerStart;
            if (monsterSoundTimer < 0)
            {
                monsterAudioSource.PlayOneShot(momonsterChasing, 1.0f);
                monsterSoundTimer = monsterSoundTimerStart;
            }
        }
    }
}