using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public bool isOpen;
    public bool instructionRecieved = false;
    public Animator doorAnimator;
    public AudioSource doorAudiosource;
    public AudioClip doorOpening;
    public AudioClip doorClosing;
    public GameObject SoundObject;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator.Play("doorClosing", 0, 0.0f);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(instructionRecieved == false) {
            if (isOpen)
            {
                doorAnimator.Play("doorClosing", 0, 0.0f);
                doorAudiosource.PlayOneShot(doorClosing, 1.0f);
                Instantiate(SoundObject, transform.position, Quaternion.identity);
                isOpen = false;
                instructionRecieved = true;
            }
            else
            {
                doorAnimator.Play("doorOpening", 0, 0.0f);
                doorAudiosource.PlayOneShot(doorOpening, 1.0f);
                Instantiate(SoundObject, transform.position, Quaternion.identity);
                isOpen = true;
                instructionRecieved = true;
            }
        }
    }
}
