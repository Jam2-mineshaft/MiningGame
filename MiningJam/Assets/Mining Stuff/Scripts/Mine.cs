﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Mine : MonoBehaviour
{
    [Header("Setup")]
    public float mineReach;
    public MinableObjectsSO coalSettings;
    public MinableObjectsSO goldSettings;
    public int currentCoal;
    public int currentGold;
    public Text coalText;
    public Text goldText;

    [Header("Audio Setup")]
    public AudioClip[] coalMiningSounds;
    public AudioClip[] goldMiningSounds;

    RaycastHit hit;

    private void Update()
    {
        MineObject();
    }

    void MineObject()
    {
        // Coal Functionality
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, mineReach) && hit.transform.tag == "Coal") // Casts a ray from the player and checks tag
        {
            if (Input.GetKeyDown(KeyCode.Space)) // If player presses correct input then add value to coal, change UI text and destroy the coal block
            {
                currentCoal += coalSettings.valueToGive;
                coalText.text = currentCoal.ToString();
                Instantiate(coalSettings.destructionParticles, hit.transform.position, Quaternion.identity);
                PlayCoalAudio(); // Plays mining audio
                Destroy(hit.transform.gameObject);
            }
        }

        // Gold Functionality
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, mineReach) && hit.transform.tag == "Gold") // Casts a ray from the player and checks tag
        {
            if (Input.GetKeyDown(KeyCode.Space)) // If player presses correct input then add value to coal, change UI text and destroy the coal block -- CHANGE SO IT FUNCTIONS WITH EACH PLAYER'S JOYSTICK
            {
                currentGold += goldSettings.valueToGive;
                goldText.text = currentGold.ToString();
                Instantiate(goldSettings.destructionParticles, hit.transform.position, Quaternion.identity);
                PlayGoldAudio(); // Plays mining audio
                Destroy(hit.transform.gameObject);
            }
        }
    }

    void PlayCoalAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = coalMiningSounds[Random.Range(0, coalMiningSounds.Length)];
        audio.Play();
    }

    void PlayGoldAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = goldMiningSounds[Random.Range(0, goldMiningSounds.Length)];
        audio.Play();
    }
}
