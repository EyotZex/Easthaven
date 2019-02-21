using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowShatter : MonoBehaviour
{
    public AudioSource windowAudiosource;
    public AudioClip shatterSound;
    public GameObject brokenGlass;
    public GameObject SoundObject;

    public int WindowHP = 2;
    public GameObject Window;

    void Start()
    {
        windowAudiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (WindowHP == 0)
        {
            WindowHP--;
            windowAudiosource.PlayOneShot(shatterSound, 1.0f);
            Instantiate(brokenGlass, transform.position, transform.rotation);
            Instantiate(SoundObject, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.6f);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            windowAudiosource.PlayOneShot(shatterSound, 1.0f);
            Instantiate(brokenGlass, transform.position, transform.rotation);
            Instantiate(SoundObject, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.6f);
        }
        if (other.gameObject.tag == "Monster")
        {
            WindowHP--;
        }
    }
}
