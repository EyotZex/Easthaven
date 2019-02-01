using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOUT : MonoBehaviour
{
    public GameObject FadeScreen;
    public float alphaLevel = 2f;

    void Start()
    {
        
    }


    void Update()
    {
        if (alphaLevel >= 0)
        {
            alphaLevel -= 1.5f * Time.deltaTime;
            FadeScreen.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
        }

    }
    
}
