using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public bool alarmOn;
    public AudioSource alarmAudioSource;
    public AudioClip alarmSound;
    public Transform soundOrigin;
    public GameObject SoundObject;
    public float timer;
    public float timerStart;

    void Start()
    {

    }

    void Update()
    {
        if (alarmOn)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                alarmAudioSource.Stop();
                alarmAudioSource.PlayOneShot(alarmSound, 1.0f);
                Instantiate(SoundObject, soundOrigin.transform.position, Quaternion.identity);
                timer = timerStart;
            }
        }
        else
        {
            alarmAudioSource.Stop();
            timer = 0;
        }
    }
}
