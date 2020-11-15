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

    // Start is called before the first frame update
    void Start()
    {
        current_speed = base_speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move Platform
        transform.position += new Vector3(current_speed * Time.deltaTime, 0, 0);

        AdjustSpeed();
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
