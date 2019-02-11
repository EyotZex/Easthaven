using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadableArea : MonoBehaviour
{

    [TextArea]
    public string textInfo;
    public TextManager _textManager;

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _textManager.Canvas.SetActive(true);
            _textManager.canvasText.text = textInfo;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _textManager.Canvas.SetActive(false);
        }
    }
}
