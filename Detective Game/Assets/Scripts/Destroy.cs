﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject target;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(target, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
