using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour
{
    public GameObject Beam1;
    public GameObject Beam2;
    public GameObject Beam3;
    public GameObject Beam4;

    public float Timer = 2f;
    public bool startTimer = false;
    public AudioClip deathSound;
    public AudioSource deathSource;
    public bool activated = false;

    void Start()
    {

    }

    void Update()
    {
        if (Beam1.activeSelf == false && Beam2.activeSelf == false && Beam3.activeSelf == false && Beam4.activeSelf == false)
        {
            Timer -= Time.deltaTime;


            if (Timer < 0)
            {
                SceneManager.LoadScene("Chapter 8");
            }

            if (!activated)
            {
                deathSource.PlayOneShot(deathSound, 1f);
                activated = true;
            }
        }
    }
}
