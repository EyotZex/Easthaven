using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{

    public bool open = false;
    public GameObject door;

    void Start()
    {
        
    }


    void Update()
    {
        if (open)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }
}
