using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private bool isHolding = false;

    public GameObject held;
    public Transform holdingSpot;

    private void Start()
    {
        holdingSpot = gameObject.transform;
    }

    private void Update()
    {
        if(isHolding)
        {
            held.transform.position = holdingSpot.position;
            held.transform.rotation = holdingSpot.rotation;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!isHolding)
            {
                if (other.gameObject.CompareTag("Coal") || other.gameObject.CompareTag("Gold"))
                {
                    held = other.gameObject;
                    isHolding = true;
                }
            }
            else
            {
                isHolding = false;
                held = null;
                Rigidbody rb = held.GetComponent<Rigidbody>();
                rb.AddForce(this.transform.forward* 100);
            }
        }
        
    }
}
