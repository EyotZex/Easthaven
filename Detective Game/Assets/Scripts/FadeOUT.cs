using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOUT : MonoBehaviour
{
    public GameObject FadeScreen;
    public float alphaLevel = 2f;
    public bool Reverse = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (!Reverse)
        {
            if (alphaLevel >= 0)
            {
                alphaLevel -= 1.5f * Time.deltaTime;
                FadeScreen.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            }
        }
        else
        {
            if (alphaLevel <= 1)
            {
                alphaLevel -= -2f * Time.deltaTime;
                FadeScreen.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            }
        }
    }
    
}
