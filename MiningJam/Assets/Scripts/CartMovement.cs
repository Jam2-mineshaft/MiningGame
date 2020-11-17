using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
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
        current_speed = base_speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move Platform
        transform.position += new Vector3(0, 0, current_speed * Time.deltaTime);

        AdjustSpeed();

        for (int i = 0; i < furnace_lights.Length; i++)
        {
            furnace_lights[i].GetComponent<Light>().intensity = current_speed / 15;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destructor"))
        {
            print("gameover");
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
