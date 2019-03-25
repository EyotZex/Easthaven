using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxController : MonoBehaviour
{
    public GameObject ThisCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            Time.timeScale = 1f;
            ThisCanvas.SetActive(false);
            return;
        }
            Time.timeScale = 0f;
    }
}
