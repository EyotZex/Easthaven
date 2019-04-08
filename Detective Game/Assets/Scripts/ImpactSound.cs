using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public GameObject SoundObject;
    public AudioSource itemAudiosource;
    public AudioClip impactSound;
    public bool soundMade = false;
    public float speed;
    public ProjectileLauncher playerProjectileLauncher;

    void Start()
    {
        playerProjectileLauncher = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ProjectileLauncher>();
        itemAudiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        playerProjectileLauncher = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ProjectileLauncher>();
        if (!soundMade)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && soundMade && playerProjectileLauncher.hasThrowable == false)
        {
            if (soundMade)
            {
                playerProjectileLauncher.hasThrowable = true;
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Monster")
        {
            if (!soundMade)
            {
                itemAudiosource.PlayOneShot(impactSound, 1.0f);
                Instantiate(SoundObject, transform.position, Quaternion.identity);
                soundMade = true;
            }
        }
    }
}
