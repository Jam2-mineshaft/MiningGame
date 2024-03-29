﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    public Cart cart;
    public float fuel_effect = 2f;

    GameManager gameManager;

    [SerializeField]
    float base_speed = 1f;

    [SerializeField]
    float max_speed = 20;

    [SerializeField]
    float speed_deficit = 0.5f;

    private float min_speed = 0;
    private float current_speed = 0;
    private ParticleSystem PS;
    public Light[] furnace_lights;
    public AudioSource cart_noise;
    public float fireSpeed;

    Vector3 crash_pos;
    bool crashed;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        PS = GetComponent<ParticleSystem>();
        current_speed = base_speed;
        crashed = false;
    }

    public void Crash()
    {
        AudioSource[] sounds = this.GetComponents<AudioSource>();

        //Move Platform
        //transform.position += new Vector3(0, 0, current_speed * Time.deltaTime);
        crash_pos = transform.position;
        crashed = true;

        sounds[1].Play();
        sounds[0].Stop();
    }

    public void StopCart()
    {
        Debug.Log("cart stop");
        AudioSource[] sounds = this.GetComponents<AudioSource>();
        sounds[0].Stop();
        current_speed = 0;
    }

    public void AddFuel()
    {
        current_speed += fuel_effect;
    }
    private void Update()
    {
        float emissionamount = current_speed / max_speed * 4;
        var emissioncontroller = PS.emission;
        emissioncontroller.rateOverTime = emissionamount;
        //var mainPS = PS.main;
       // mainPS.simulationSpeed = fireSpeed;

        if (crashed)
        {
            transform.position = crash_pos;
        }
      
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.GameFinished())
        {
            //Move Platform
            transform.position += new Vector3(0, 0, current_speed * Time.deltaTime);
            AdjustSpeed();

            for (int i = 0; i < furnace_lights.Length; i++)
            {
                furnace_lights[i].intensity = current_speed * speed_deficit / 45;
            }
            AdjustCartAudio();
            //if (current_speed < 30f)
            //{
            //    fireSpeed = 1f - (30f - current_speed) / 30f;
            //}
        }
    }

    void AdjustSpeed()
    {
        if (current_speed > max_speed)
        {
            current_speed = max_speed;
        }

        if (current_speed < min_speed)
        {
            current_speed = min_speed;
        }

        current_speed -= speed_deficit * Time.deltaTime;

      
    }

    void AdjustCartAudio()
    {
        if (current_speed < 30f)
        {
            cart_noise.pitch = 1f - (30f - current_speed) / 30f;
            cart_noise.volume = 1f - (30f - current_speed) / 30f;
        }
        /*if (current_speed < 25f)
        {
            cart_noise.volume = 1f - (25f - current_speed) / 25f;
        }*/
    }
}
