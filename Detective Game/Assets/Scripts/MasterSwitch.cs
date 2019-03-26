using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSwitch : MonoBehaviour
{
    public bool interactRange = false;
    public Transform circleOrigin;
    public LayerMask playerLayer;
    public float maskSize;

    public TextManager _textManager;
    public string textToInteract = "Press E to interact";
    private bool CanBeInteracted;
    public AutomaticDoor automaticDoorScript;

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
    }

    void Update()
    {

        if (CanBeInteracted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (automaticDoorScript.isOpen == false)
                {
                    automaticDoorScript.instructionRecieved = false;
                }
                else
                {
                    automaticDoorScript.instructionRecieved = false;
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
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = false;
            _textManager.Canvas.SetActive(false);
        }
    }
}
