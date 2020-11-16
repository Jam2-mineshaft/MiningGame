using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorMovement : MonoBehaviour
{
    public float current_speed = 5.0f;
    public float cam_speed = 0.3f;
    public Camera cam;

    private int range = 60;

    public GameObject cart;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart_Destructor"))
        {
            print("gameoverB");
        }
    }

    // Update is called once per frame
    void Update()
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

        cam.transform.localPosition = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0) * cam_speed;
        transform.position += new Vector3(0, 0, current_speed * Time.deltaTime);
    }
}
