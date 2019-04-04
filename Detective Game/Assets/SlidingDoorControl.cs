using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorControl : MonoBehaviour
{
    public SlidingDoor slidingDoorScript;
    public bool CanBeInteracted;
    public string textToInteract = "Press E to interact";
    public TextManager _textManager;

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
        slidingDoorScript._Animator.Play("SlidingDoorClosing");
        slidingDoorScript.open = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanBeInteracted)
        {
            if (!slidingDoorScript.open)
            {
                slidingDoorScript._Animator.Play("SlidingDoorOpening");
                slidingDoorScript.open = true;
            }
            else
            {
                slidingDoorScript._Animator.Play("SlidingDoorClosing");
                slidingDoorScript.open = false;
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
            if (!slidingDoorScript.open)
            {
                slidingDoorScript._Animator.Play("SlidingDoorOpening");
                slidingDoorScript.open = true;
            }
            else
            {
                slidingDoorScript._Animator.Play("SlidingDoorClosing");
                slidingDoorScript.open = false;
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

