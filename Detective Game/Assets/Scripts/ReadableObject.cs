using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadableObject : MonoBehaviour{

    public bool signActive;
    public Text textBox;
    public GameObject textBoxObject;
    public bool CanBeInteracted;
    [TextArea]
    public string textInfo;


    void Update(){
        if (Input.GetMouseButtonDown(1) && CanBeInteracted)
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
            textBoxObject.SetActive(false);
            CanBeInteracted = false;
            signActive = false;
        }
    }
}

