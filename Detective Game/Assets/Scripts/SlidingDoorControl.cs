using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorControl : MonoBehaviour
{
    public SlidingDoor slidingDoorScript;
    public bool CanBeInteracted;
    public string textToInteract = "Press E to interact";
    public TextManager _textManager;
    public AudioSource _audioSource;
    public AudioClip doorSound;
    public float timer;
    public float timerStart;

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
        slidingDoorScript.open = false;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && CanBeInteracted)
        {
            if (timer <= 0)
            {
                if (!slidingDoorScript.open)
                {
                    slidingDoorScript._Animator.Play("SlidingDoorClosing");
                    slidingDoorScript.open = true;
                    _audioSource.PlayOneShot(doorSound);
                    timer = timerStart;
                }
                else
                {
                    slidingDoorScript._Animator.Play("SlidingDoorOpening");
                    slidingDoorScript.open = false;
                    _audioSource.PlayOneShot(doorSound);
                    timer = timerStart;
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = true;
            _textManager.Canvas.SetActive(true);
            _textManager.canvasText.text = textToInteract;
        }
        if (other.gameObject.tag == "Projectile")
        {
            if (timer <= 0)
            {
                if (!slidingDoorScript.open)
                {
                    slidingDoorScript._Animator.Play("SlidingDoorClosing");
                    slidingDoorScript.open = true;
                    _audioSource.PlayOneShot(doorSound);
                    timer = timerStart;
                }
                else
                {
                    slidingDoorScript._Animator.Play("SlidingDoorOpening");
                    slidingDoorScript.open = false;
                    _audioSource.PlayOneShot(doorSound);
                    timer = timerStart;
                }
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _textManager.Canvas.SetActive(false);
            CanBeInteracted = false;
        }
    }
}

