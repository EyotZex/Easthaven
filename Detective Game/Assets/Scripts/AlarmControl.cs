using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmControl : MonoBehaviour
{

    public Alarm alarmScript;
    public bool CanBeInteracted;

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
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = false;
        }
    }
}

   