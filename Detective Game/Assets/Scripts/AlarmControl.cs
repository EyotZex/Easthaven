﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmControl : MonoBehaviour
{

    public Alarm alarmScript;
    public bool CanBeInteracted;
    public string textToInteract = "Press E to interact";
    public TextManager _textManager;

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanBeInteracted)
        {
            if (alarmScript.alarmOn)
            {
                alarmScript.alarmOn = false;
            }
            else
            {
                alarmScript.alarmOn = true;
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
            alarmScript.alarmOn = true;
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

   