using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadableObject : MonoBehaviour
{
    public bool interactRange = false;
    public Transform Origin;
    public LayerMask playerLayer;
    public float maskSize;
    public bool signActive;
    public Text textBox;
    public GameObject textBoxObject;
    [TextArea]
    public string textInfo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interactRange = Physics2D.OverlapCircle(Origin.position, maskSize, playerLayer);

        if (interactRange)
        {
            if(Input.GetMouseButtonDown(1))
            {
                if (!signActive)
                {
                    textBoxObject.SetActive(true);
                    textBox.text = textInfo;
                    signActive = true;
                }
                else
                {
                    textBoxObject.SetActive(false);
                    signActive = false;
                }
            }
        }
        else
        {
            textBoxObject.SetActive(false);
            signActive = false;
        }
    }
}

