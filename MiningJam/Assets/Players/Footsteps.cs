﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;
    Rigidbody Rb;
    AudioSource audsource;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        audsource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Rb.velocity.magnitude > 1f && audsource.isPlaying == false)
        {
            audsource.volume = Random.Range(0.4f, 0.6f);
            audsource.pitch = Random.Range(0.8f, 1.2f);
            audsource.Play();
        }
    }
}
