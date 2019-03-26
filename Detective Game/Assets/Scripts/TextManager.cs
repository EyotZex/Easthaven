using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public bool textBox;
    public GameObject Canvas;
    public GameObject Canvas2;
    public Text canvasText;
    public Text canvasText2;
    [TextArea]
    public string textInfo;

    public bool levelStarted = false;


    void Start()
    {

        Time.timeScale = 0f;
        Canvas2.SetActive(true);
        canvasText2.text = textInfo;
        Canvas.SetActive(false);
    }

    void Update()
    {
        if (!levelStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 1f;
                Canvas2.SetActive(false);
                Canvas.SetActive(false);
                levelStarted = true;
            }
        }
    }
}

