using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{

    public bool open = false;
    public GameObject door;
    public Animator _Animator;

    void Start()
    {
        _Animator = GetComponent<Animator>();
    }
}
