using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamControl : MonoBehaviour
{
    public bool lightOn;
    public bool beamActive;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject Beam;
    public GameObject ButtonLight;
    public bool CanBeInteracted;
    public string textToInteract = "Press E to interact";
    public TextManager _textManager;
    public bool buttonlock;
    public float LightTimer;
    public float LightTimerStart;
    public GameObject SoundObject;
    public Transform soundOrigin;
    public AudioSource _AudioSource;
    public AudioClip correct;
    public AudioClip wrong;
    public AudioSource _audioSource;
    public AudioClip failSound;

    void Start()
    {
        beamActive = true;
        _textManager = GameObject.FindGameObjectWithTag("Admin").GetComponentInChildren<TextManager>();
        LightTimer = LightTimerStart;
    }

    void Update()
    {
        if (beamActive)
        {
            LightTimer -= Time.deltaTime;

            if (LightTimer <= 0)
            {
                if (lightOn)
                {
                    ButtonLight.SetActive(false);
                    lightOn = false;
                    LightTimer = LightTimerStart;
                    buttonlock = false;
                }
                else
                {
                    ButtonLight.SetActive(true);
                    lightOn = true;
                    LightTimer = LightTimerStart;
                    buttonlock = false;
                }
            }


            if (Input.GetKeyDown(KeyCode.E) && CanBeInteracted)
            {
                if (lightOn && !buttonlock)
                {
                    if (light2.activeSelf == false)
                    {
                        light3.SetActive(false);
                    }
                    if (light1.activeSelf == false)
                    {
                        light2.SetActive(false);
                    }
                    light1.SetActive(false);
                    buttonlock = true;
                }
                else
                {
                    Instantiate(SoundObject, soundOrigin.transform.position, Quaternion.identity);
                    _audioSource.PlayOneShot(failSound);
                    ButtonLight.SetActive(false);
                    lightOn = false;
                    LightTimer = 5f;
                }
            }
            if (light3.activeSelf == false)
            {
                Beam.SetActive(false);
                ButtonLight.SetActive(false);
                beamActive = false;

            }
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
            _textManager.Canvas.SetActive(false);
            CanBeInteracted = false;
        }
    }
}

