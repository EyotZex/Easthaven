using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadableObject : MonoBehaviour{

    public bool signActive;
    public bool CanBeInteracted;
    [TextArea]
    public string textInfo;
    public string textToInteract = "Press E to interact";
    public TextManager _textManager;

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.E) && CanBeInteracted)
        {
            if (!signActive)
            {
                Time.timeScale = 0f;
                _textManager.Canvas2.SetActive(true);
                _textManager.canvasText2.text = textInfo;
                signActive = true;
                _textManager.Canvas.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
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
            _textManager.Canvas.SetActive(false);
            CanBeInteracted = false;
            signActive = false;
        }
    }
}

