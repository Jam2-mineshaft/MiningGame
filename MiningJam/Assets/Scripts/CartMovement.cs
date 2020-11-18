using System.Collections;
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
    float speed_deficit = 0.1f;

    private float min_speed = 0;
    private float current_speed = 0;

    public GameObject[] furnace_lights;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        current_speed = base_speed;
    }

    public void Crash()
    {
        AudioSource[] sounds = this.GetComponents<AudioSource>();

        //Move Platform
        transform.position += new Vector3(0, 0, current_speed * Time.deltaTime);

        sounds[1].Play();
        sounds[0].Stop();
    }

    public void StopCart()
    {
        AudioSource[] sounds = this.GetComponents<AudioSource>();
        sounds[0].Stop();
    }

    public void AddFuel()
    {
        current_speed += fuel_effect;
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
                furnace_lights[i].GetComponent<Light>().intensity = current_speed * speed_deficit / 45;
            }
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
}
