using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl2 : MonoBehaviour
{
    public DoorDetector LeftDetector;
    public DoorDetector RightDetector;

    public bool keyRequired;
    private bool doorIsOpen;

    private Animator doorAnimator;
    private AudioSource doorAudiosource;
    public AudioClip doorOpening;
    public AudioClip doorClosing;
    public AudioClip doorLocked;
    public AudioClip doorAttacked;

    private bool doorOpenLeft = false;
    private bool doorOpenRight = false;

    public GameObject doorCollider;
    private float ColliderDisableTimer = 0f;
    private float ColliderDisableTimerStart = 0.5f;

    public Transform soundOrigin;
    public GameObject PlayerSoundObject;
    public GameObject MonsterSoundObject;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorAudiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ColliderDisableTimer -= Time.deltaTime;
        if (ColliderDisableTimer <= 0)
        {
            doorCollider.GetComponent<Collider2D>().enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.E) && LeftDetector.PlayerInRange && !keyRequired)
        {
            if (doorIsOpen)
            {
                if (doorOpenLeft)
                {
                    doorAnimator.Play("LeftdoorClosing", 0, 0.0f);
                }
                else
                {
                    doorAnimator.Play("doorClosing", 0, 0.0f);
                }
                doorAudiosource.PlayOneShot(doorClosing, 1.0f);
                doorIsOpen = false;
                doorOpenLeft = false;
                doorOpenRight = false;
                DisableCollider();
                CreateNoise();
            }
            else
            {
                doorAnimator.Play("LeftdoorOpening", 0, 0.0f);
                doorAudiosource.PlayOneShot(doorOpening, 1.0f);
                doorIsOpen = true;
                doorOpenLeft = true;
                DisableCollider();
                CreateNoise();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && RightDetector.PlayerInRange && !keyRequired)
        {

            if (doorIsOpen)
            {
                if (doorOpenRight)
                {
                    doorAnimator.Play("doorClosing", 0, 0.0f);
                }
                else
                {
                    doorAnimator.Play("LeftdoorClosing", 0, 0.0f);
                }
                doorAudiosource.PlayOneShot(doorClosing, 1.0f);
                doorIsOpen = false;
                doorOpenRight = false;
                doorOpenLeft = false;
                DisableCollider();
                CreateNoise();
            }
            else
            {
                doorAnimator.Play("doorOpening", 0, 0.0f);
                doorAudiosource.PlayOneShot(doorOpening, 1.0f);
                doorIsOpen = true;
                doorOpenRight = true;
                DisableCollider();
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && keyRequired)
        {
            if (LeftDetector.PlayerInRange || RightDetector.PlayerInRange)
            {
                doorAudiosource.PlayOneShot(doorLocked, 1.0f);
                CreateNoise();
            }
        }

        if (LeftDetector.MonsterInRange || RightDetector.MonsterInRange)
        {
            doorAnimator.Play("doorLocked", 0, 0.0f);
            Instantiate(MonsterSoundObject, soundOrigin.transform.position, Quaternion.identity);
            doorAudiosource.PlayOneShot(doorAttacked, 1.0f);
            LeftDetector.MonsterInRange = false;
            RightDetector.MonsterInRange = false;
        }
    }
    public void DisableCollider()
    {
        doorCollider.GetComponent<Collider2D>().enabled = false;
        ColliderDisableTimer = ColliderDisableTimerStart;
    }
    public void CreateNoise()
    {
        if (LeftDetector.PlayerInRange || RightDetector.PlayerInRange)
        {
            Instantiate(PlayerSoundObject, soundOrigin.transform.position, Quaternion.identity);
        }
    }
}