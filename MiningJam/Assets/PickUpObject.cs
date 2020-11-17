using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private bool isHolding = false;

    public GameObject ob;
    public Transform holdingSpot;

    Mine mining;

    private void Start()
    {
        mining = this.GetComponent<Mine>();
    }

    private void Update()
    {
        //TODO : CHANGE INPUT BUTTON FROM 1 KEY TO CONTROLLER BUTTON

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!isHolding)
            {
                if (ob != null)
                {
                    if (ob.gameObject.CompareTag("Coal"))
                    {
                        ob.transform.parent = holdingSpot.transform;
                        isHolding = true;
                    }
                    else if (ob.gameObject.CompareTag("Gold"))
                    {
                        Destroy(ob);
                        mining.currentGold += mining.goldSettings.valueToGive;
                    }
                }
            }
            else
            {
                if (ob.gameObject.CompareTag("Coal"))
                {
                    isHolding = false;
                    Rigidbody rb = ob.GetComponent<Rigidbody>();
                    rb.AddForce(this.transform.forward * 100);
                    ob = null;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ob == null)
        {
            ob = other.gameObject;
        }
        else
        {
            return;
        }
    }
}
