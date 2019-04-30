using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabChaseAdmin : MonoBehaviour
{
    public GameObject glass1;
    public GameObject glass2;
    public AudioSource Audiosource;
    public AudioClip ChaseSound;
    public GameObject SoundObject;

    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            glass1.SetActive(false);
            glass2.SetActive(false);
            Audiosource.PlayOneShot(ChaseSound, 1.0f);
            Instantiate(SoundObject, transform.position, Quaternion.identity);
        }
    }
}
