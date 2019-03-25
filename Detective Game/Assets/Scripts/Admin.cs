using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Admin : MonoBehaviour
{
    public bool PlayerDead;
    public AlternativePlayerControls playerScript;
    public FadeOUT fadeScript;
    public float Timer = 2f;
    public bool startTimer = false;
    public string sceneToLoad;
    public int deathScenario = 0;
    public bool activated = false;
    public AudioClip deathSound;
    public AudioSource deathSource;


    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<AlternativePlayerControls>();
        deathSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (startTimer)
        {
            Timer -= Time.deltaTime;
        }

        if (Timer < 0)
        {
            if (deathScenario == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (deathScenario == 1)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        if (!activated) {
            if (PlayerDead)
            {
                fadeScript.Reverse = true;
                startTimer = true;
                playerScript.playerDied = true;
                deathSource.PlayOneShot(deathSound, 1f);
                activated = true;
            }
        }
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void Chapter0() {
        SceneManager.LoadScene("Chapter 0");
    }

    public void Chapter1() {
        SceneManager.LoadScene("Chapter 1");
    }

    public void Chapter2() {
        SceneManager.LoadScene("Chapter 2");
    }

    public void Chapter3() {
        SceneManager.LoadScene("Chapter 3");
    }

    public void Chapter4() {
        SceneManager.LoadScene("Chapter 4");
    }
    public void Chapter5()
    {
        SceneManager.LoadScene("Chapter 5");
    }
    public void Chapter6()
    {
        SceneManager.LoadScene("Chapter 6");
    }
    public void Chapter7()
    {
        SceneManager.LoadScene("Chapter 7");
    }
}
