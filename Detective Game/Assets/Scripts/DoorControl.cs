﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour {

	public bool hasKey = false;
	public bool isOpen = false;
    private bool doorOpenLeft = false;
    private bool doorOpenRight = false;

    private bool interactRangeLeft = false;
    private bool interactRangeRight = false;
    public Transform LeftOrigin;
    public Transform RightOrigin;
    public LayerMask playerLayer;
	public float maskSize;

	public GameObject SoundObject;
	public Animator doorAnimator;
	public AudioSource doorAudiosource;
	public AudioClip doorOpening;
	public AudioClip doorClosing;
	public AudioClip doorLocked;

    public GameObject doorCollider;
    private float ColliderDisableTimer;
    private float ColliderDisableTimerStart;

    private bool signActive;
    private bool CanBeInteracted;
    public TextManager _textManager;
    [TextArea]
    public string textInfo;

    void Start () {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
        doorAnimator = GetComponent<Animator> ();
		doorAudiosource = GetComponent<AudioSource> ();
		if (isOpen) {
			doorAnimator.Play ("doorClosing", 0, 0.0f);
			isOpen = false;
		}
	}
    void Update()
    {
        ColliderDisableTimer -= Time.deltaTime;
        if (ColliderDisableTimer <= 0)
        {
            doorCollider.GetComponent<Collider2D>().enabled = true;
        }

        interactRangeLeft = Physics2D.OverlapCircle(LeftOrigin.position, maskSize, playerLayer);
        interactRangeRight = Physics2D.OverlapCircle(RightOrigin.position, maskSize, playerLayer);

        if (interactRangeRight)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (hasKey)
                {
                    if (isOpen)
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
                        Instantiate(SoundObject, transform.position, Quaternion.identity);
                        isOpen = false;
                        doorOpenRight = false;
                        doorOpenLeft = false;
                        DisableCollider();
                    }
                    else
                    {
                        doorAnimator.Play("doorOpening", 0, 0.0f);
                        doorAudiosource.PlayOneShot(doorOpening, 1.0f);
                        Instantiate(SoundObject, transform.position, Quaternion.identity);
                        isOpen = true;
                        doorOpenRight = true;
                        DisableCollider();
                    }
                }
                else
                {
                    doorAnimator.Play("doorLocked", 0, 0.0f);
                    doorAudiosource.PlayOneShot(doorLocked, 1.0f);
                    Instantiate(SoundObject, transform.position, Quaternion.identity);
                }
            }
        }
        if (interactRangeLeft)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (hasKey)
                {
                    if (isOpen)
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
                        Instantiate(SoundObject, transform.position, Quaternion.identity);
                        isOpen = false;
                        doorOpenLeft = false;
                        doorOpenRight = false;
                        DisableCollider();
                    }
                    else
                    {
                        doorAnimator.Play("LeftdoorOpening", 0, 0.0f);
                        doorAudiosource.PlayOneShot(doorOpening, 1.0f);
                        Instantiate(SoundObject, transform.position, Quaternion.identity);
                        isOpen = true;
                        doorOpenLeft = true;
                        DisableCollider();
                    }
                }
                else
                {
                    doorAnimator.Play("doorLocked", 0, 0.0f);
                    doorAudiosource.PlayOneShot(doorLocked, 1.0f);
                    Instantiate(SoundObject, transform.position, Quaternion.identity);

                }
            }
        }
        if (Input.GetMouseButtonDown(1) && CanBeInteracted)
        {
            if (!signActive)
            {
                _textManager.Canvas.SetActive(true);
                _textManager.canvasText.text = textInfo;
                signActive = true;
            }
            else
            {
                _textManager.Canvas.SetActive(false);
                signActive = false;
            }
        }
    }
	public void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = true;
        }
        if (other.gameObject.tag == "Monster") {
			if (!isOpen) {
				doorAnimator.Play ("doorLocked", 0, 0.0f);
				doorAudiosource.PlayOneShot (doorLocked, 1.0f);
                Instantiate(SoundObject, transform.position, Quaternion.identity);
            }
		}
	}
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _textManager.Canvas.SetActive(false);
            CanBeInteracted = false;
            signActive = false;
        }
    }
    public void DisableCollider()
    {
        doorCollider.GetComponent<Collider2D>().enabled = false;
        ColliderDisableTimer = ColliderDisableTimerStart;
    }
}