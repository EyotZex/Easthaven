﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Admin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
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
}
