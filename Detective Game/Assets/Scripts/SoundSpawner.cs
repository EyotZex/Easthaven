﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSpawner : MonoBehaviour {

    public GameObject SoundObject;
    public GameObject SoundMedium;
    public GameObject SoundSmall;
    public GameObject SoundLarge;
    public Transform player;
    public PlayerController playerScript;
    public float SoundTimer;
    public float FullSoundTimer;
    public float SoundTimerRunning;
    public float SoundTimerSneaking;

    public AudioSource playerAudioSource;
    public AudioClip footsteps;
    public AudioClip walkingSound;
    public AudioClip runningSound;
    public AudioClip[] ListOfSounds;

    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    void Update () {
		SoundTimer -= Time.deltaTime;
		if (!playerScript.playerStill){
			if (SoundTimer <= 0) {
				Invoke ("MakeSound", 0.0f);
			}
		}
  
	}
	void MakeSound (){
        if (playerScript.speed == playerScript.RunSpeed)
        {
            SoundObject = SoundLarge;
//            footsteps = runningSound;
            SoundTimer = SoundTimerRunning;
        }
        if (playerScript.speed == playerScript.SneakSpeed)
        {
            SoundObject = SoundSmall;
 //           footsteps = null;
            SoundTimer = SoundTimerSneaking;
        }
        if (playerScript.speed == playerScript.WalkSpeed)
        {
            SoundObject = SoundMedium;
//            footsteps = walkingSound;
            SoundTimer = FullSoundTimer;
        }
        Instantiate (SoundObject, player.transform.position, Quaternion.identity);
        RunningSteps();
 //       playerAudioSource.Stop();
//        playerAudioSource.PlayOneShot(footsteps, 1.0f);
    }
    public void RunningSteps()
    {
        playerAudioSource.Stop();
        int rndNo = Random.Range(0, ListOfSounds.Length);
        footsteps = ListOfSounds[rndNo];
        playerAudioSource.PlayOneShot(footsteps, 1.0f);


    }
}