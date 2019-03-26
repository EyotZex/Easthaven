using System.Collections;
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

    public Transform soundOrigin;

    public GameObject SoundObject;
    public Animator doorAnimator;
    public AudioSource doorAudiosource;
    public AudioClip doorOpening;
    public AudioClip doorClosing;
    public AudioClip doorLocked;

    public GameObject doorCollider;
    public float ColliderDisableTimer;
    public float ColliderDisableTimerStart;

    private bool signActive;
    private bool CanBeInteracted;
    public TextManager _textManager;
    public string textToInteract = "Press E to interact";

    public int DoorHP = 5;
    public GameObject door;

    [TextArea]
    public string textInfo;


    void Start() {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
        doorAnimator = GetComponent<Animator>();
        doorAudiosource = GetComponent<AudioSource>();
        if (isOpen) {
            doorAnimator.Play("doorClosing", 0, 0.0f);
            isOpen = false;
        }
    }
    void Update()
    {
        if (DoorHP == 0)
        {
            DoorHP--;
            doorAudiosource.PlayOneShot(doorLocked, 1.0f);
            Destroy(door, 0.4f);
        }
        ColliderDisableTimer -= Time.deltaTime;
        if (ColliderDisableTimer <= 0)
        {
            doorCollider.GetComponent<Collider2D>().enabled = true;
        }

        interactRangeLeft = Physics2D.OverlapCircle(LeftOrigin.position, maskSize, playerLayer);
        interactRangeRight = Physics2D.OverlapCircle(RightOrigin.position, maskSize, playerLayer);

        if (Input.GetKeyDown(KeyCode.E) && CanBeInteracted)
        {
            if (hasKey)
            {
                if (interactRangeRight)
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
                        Instantiate(SoundObject, soundOrigin.transform.position, Quaternion.identity);
                        isOpen = false;
                        doorOpenRight = false;
                        doorOpenLeft = false;
                        DisableCollider();
                    }
                    else
                    {
                        doorAnimator.Play("doorOpening", 0, 0.0f);
                        doorAudiosource.PlayOneShot(doorOpening, 1.0f);
                        Instantiate(SoundObject, soundOrigin.transform.position, Quaternion.identity);
                        isOpen = true;
                        doorOpenRight = true;
                        DisableCollider();
                    }
                }


                if (interactRangeLeft)
                {
                    if (Input.GetKeyDown(KeyCode.E))
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
                            Instantiate(SoundObject, soundOrigin.transform.position, Quaternion.identity);
                            isOpen = false;
                            doorOpenLeft = false;
                            doorOpenRight = false;
                            DisableCollider();
                        }
                        else
                        {
                            doorAnimator.Play("LeftdoorOpening", 0, 0.0f);
                            doorAudiosource.PlayOneShot(doorOpening, 1.0f);
                            Instantiate(SoundObject, soundOrigin.transform.position, Quaternion.identity);
                            isOpen = true;
                            doorOpenLeft = true;
                            DisableCollider();
                        }
                    }
                }
            }
            else
            {
                if (!signActive)
                {
                    Time.timeScale = 0f;
                    _textManager.Canvas2.SetActive(true);
                    _textManager.canvasText2.text = textInfo;
                    signActive = true;
                    _textManager.Canvas.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    doorAnimator.Play("doorLocked", 0, 0.0f);
                    doorAudiosource.PlayOneShot(doorLocked, 1.0f);
                    Instantiate(SoundObject, soundOrigin.transform.position, Quaternion.identity);
                }
                else
                {
                    Time.timeScale = 1f;
                    _textManager.Canvas2.SetActive(false);
                    signActive = false;
                    _textManager.Canvas.SetActive(true);
                    _textManager.canvasText.text = textToInteract;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
        if (CanBeInteracted)
        {
            if (interactRangeLeft || interactRangeRight)
            {

            }
        }

    }

	public void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = true;
            _textManager.Canvas.SetActive(true);
            _textManager.canvasText.text = textToInteract;
        }
        if (other.gameObject.tag == "Monster") {
			if (!isOpen) {
                DoorHP--;
				doorAnimator.Play ("doorLocked", 0, 0.0f);
				doorAudiosource.PlayOneShot (doorLocked, 1.0f);
                Instantiate(SoundObject, soundOrigin.transform.position, Quaternion.identity);
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