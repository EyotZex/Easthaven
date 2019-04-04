using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsters;
    public GameObject monster;
    private int index;
    public float timer;
    public float timerstart;

    void Start()
    {
        timer = timerstart;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            index = Random.Range(0, monsters.Length);
            monster = monsters[index];
            monster.SetActive(true);
            timer = timerstart;
        }
    }
}
