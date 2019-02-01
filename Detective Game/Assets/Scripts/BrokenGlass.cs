using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGlass : MonoBehaviour
{
    public AudioSource windowAudiosource;
    public AudioClip shatterSound;
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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Monster")
        {
            windowAudiosource.PlayOneShot(shatterSound, 1.0f);
            Instantiate(SoundObject, transform.position, Quaternion.identity);
        }
    }
}
