using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowShatter : MonoBehaviour
{
    public AudioSource windowAudiosource;
    public AudioClip shatterSound;
    public GameObject brokenGlass;
    public GameObject SoundObject;

    // Start is called before the first frame update
    void Start()
    {
        windowAudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
