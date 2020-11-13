using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;
    AudioSource audsource;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        audsource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if(cc.velocity.magnitude > 1f && audsource.isPlaying == false)
        {
            audsource.volume = Random.Range(0.7f, 1);
            audsource.pitch = Random.Range(0.8f, 1.2f);
            audsource.Play();
        }
    }
}
