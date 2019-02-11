using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadableObject : MonoBehaviour{

    public bool signActive;
    public bool CanBeInteracted;
    [TextArea]
    public string textInfo;
    public TextManager _textManager;

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
    }

    void Update(){
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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = true;
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

