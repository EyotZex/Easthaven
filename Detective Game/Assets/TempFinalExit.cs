using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempFinalExit : MonoBehaviour
{

    public GameObject beam1;
    public GameObject beam2;
    public GameObject beam3;
    public GameObject beam4;
    public string sceneToLoad;

    void Start()
    {
        
    }


    void Update()
    {
        if ((beam1.activeSelf == false) && (beam2.activeSelf == false) && (beam3.activeSelf == false) && (beam4.activeSelf == false))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
