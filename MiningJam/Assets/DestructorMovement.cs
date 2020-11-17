using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorMovement : MonoBehaviour
{
    GameManager gameManager;

    public float current_speed = 5.0f;
    public float cam_speed = 0.3f;
    public Camera cam;

    private int range = 60;

    private GameObject cart;
    private GameObject rocks;

    private bool destructor_active = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        cart = gameManager.Cart;
        rocks = this.transform.Find("Rock Spawner").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart_Destructor"))
        {
            rocks.transform.parent = null;
            RockSpawner rockSpawner = rocks.GetComponent<RockSpawner>();

            StartCoroutine(rockSpawner.SpawnRocks());
            gameManager.EndGame();
        }
    }

    public void DisableDestructor()
    {
        ParticleSystem rock_particles = this.transform.Find("Rock Particles").gameObject.GetComponent<ParticleSystem>();
        ParticleSystem dust_particles = this.GetComponent<ParticleSystem>();

        ParticleSystem.EmissionModule em = dust_particles.emission;
        em.enabled = false;

        rock_particles.Stop();

        destructor_active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (destructor_active)
        {
            float dist = Vector3.Distance(this.transform.position, cart.transform.position);

            if (dist < range)
            {
                cam_speed = 1 - (dist / range);
            }
            else
            {
                cam_speed = 0;
            }

            cam.transform.localPosition = new Vector3(Random.Range(-0.6f, 0.6f), Random.Range(-0.6f, 0.6f), 0) * cam_speed;
        }

        if (!gameManager.GameFinished())
        {
            transform.position += new Vector3(0, 0, current_speed * Time.deltaTime);
        }
    }
}
