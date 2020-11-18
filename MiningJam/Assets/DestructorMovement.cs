using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorMovement : MonoBehaviour
{
    GameManager gameManager;

    public float current_speed = 5.0f;

    public float cam_speed;
    private float cam_multiplier = 0;
    public Camera cam;

    private int range = 60;

    private GameObject cart;
    private GameObject rocks;

    private bool destructor_active = true;
    private bool hit_cart = false;

    private float tParam = 0;
    private float lerp_speed = 0.3f;

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
            hit_cart = true;

            rocks.transform.parent = null;
            RockSpawner rockSpawner = rocks.GetComponent<RockSpawner>();

            StartCoroutine(rockSpawner.SpawnRocks());
            cart.GetComponent<CartMovement>().Crash();
            gameManager.hasCaveInHappened = true;
            gameManager.EndGame();
        }
    }

    public void DisableDestructor()
    {
        AudioSource rumble = this.GetComponent<AudioSource>();
        StartCoroutine(StartFade(rumble, 3, 0));

        ParticleSystem rock_particles = this.transform.Find("Rock Particles").gameObject.GetComponent<ParticleSystem>();
        ParticleSystem dust_particles = this.GetComponent<ParticleSystem>();

        ParticleSystem.EmissionModule em = dust_particles.emission;
        em.enabled = false;

        rock_particles.Stop();
        destructor_active = false;
    }

    IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GameFinished())
        {
            if (!hit_cart)
            {
                transform.position += new Vector3(0, 0, current_speed * Time.deltaTime);
                cam_multiplier = 0.6f;
            }

        }
        else if (hit_cart)
        {
            if (tParam < 1)
            {
                tParam += Time.deltaTime * lerp_speed;
                cam_multiplier = Mathf.Lerp(2, 0, tParam);
            }
            else
            {
                hit_cart = false;
            }
        }
        else
        {
            cam_multiplier = 0.6f;
        }

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
        }
        else
        {
            cam_multiplier = 0;
        }
        cam.transform.localPosition = new Vector3(Random.Range(-cam_multiplier, cam_multiplier), Random.Range(-cam_multiplier, cam_multiplier), 0) * cam_speed;
    }
}
