using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip[] coalMiningSounds;
    public AudioClip[] goldMiningSounds;

    public void PlayCoalAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = coalMiningSounds[Random.Range(0, coalMiningSounds.Length)];
        audio.Play();
    }

    public void PlayGoldAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = goldMiningSounds[Random.Range(0, goldMiningSounds.Length)];
        audio.Play();
    }
}
