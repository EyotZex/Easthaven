using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetector : MonoBehaviour
{
    public bool PlayerInRange;
    public bool MonsterInRange;

    public TextManager _textManager;
    private string textToInteract = "Press E to interact";

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInRange = true;
            _textManager.Canvas.SetActive(true);
            _textManager.canvasText.text = textToInteract;
        }
        if (other.gameObject.tag == "Monster")
        {
            MonsterInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInRange = false;
            _textManager.Canvas.SetActive(false);
        }
        if (other.gameObject.tag == "Monster")
        {
            MonsterInRange = false;
        }
    }
}
