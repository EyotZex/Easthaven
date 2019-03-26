using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

	public DoorControl doorScript;
    private bool CanBeInteracted;
    public TextManager _textManager;
    public string textToInteract = "Press E to interact";

    void Start()
    {
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanBeInteracted)
        {
            print("key");
            doorScript.hasKey = true;
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = true;
            _textManager.Canvas.SetActive(true);
            _textManager.canvasText.text = textToInteract;
        }
    }
    

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanBeInteracted = false;
            _textManager.Canvas.SetActive(false);
        }
    }
}
