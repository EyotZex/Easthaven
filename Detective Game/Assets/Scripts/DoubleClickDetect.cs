using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClickDetect : MonoBehaviour {

    public int Clicks = 0;
    public bool DoubleClicked = false;
    public float timer;
    public float timerStart;

    public int Clicks2 = 0;
    public bool DoubleClicked2 = false;
    public float timer2;
    public float timerStart2;

    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Clicks = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Clicks++;
            timer = timerStart;

        }
        if(Clicks == 2)
        {
            Clicks = 0;
            DoubleClicked = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            DoubleClicked = false;
            timer = timerStart;
        }


        timer2 -= Time.deltaTime;
        if (timer2 < 0)
        {
            Clicks2 = 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Clicks2++;
            timer2 = timerStart2;

        }
        if (Clicks2 == 2)
        {
            Clicks2 = 0;
            DoubleClicked2 = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            DoubleClicked2 = false;
            timer2 = timerStart2;
        }
    }
}
