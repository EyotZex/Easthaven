using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public Admin admin;


    void Start()
    {
        admin = GameObject.FindGameObjectWithTag("Admin").GetComponent<Admin>();
    }


    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
                admin.PlayerDead = true;
        }
    }
}