using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public bool isHolding = false;

    public GameObject obj;
    public Transform holdingSpot;
    public int whatPlayerIsThis;

    Mine mining;

    private void Start()
    {
        mining = this.GetComponent<Mine>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Gold_Ore") || other.gameObject.CompareTag("Coal_Ore"))
        {
            if (Input.GetKey(KeyCode.Joystick1Button0) && whatPlayerIsThis == 0)
            {
                mining.MineObject(other.gameObject);
            }

            if (Input.GetKey(KeyCode.Joystick2Button0) && whatPlayerIsThis == 1)
            {
                mining.MineObject(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Coal"))
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) && whatPlayerIsThis == 0)
            { 
                if (!isHolding)
                {
                    if (other.gameObject.CompareTag("Coal"))
                    {
                        obj = other.gameObject;
                        obj.transform.parent = holdingSpot.transform;
                        obj.transform.position = Vector3.Lerp(obj.transform.position, holdingSpot.transform.position, 10 * Time.deltaTime);
                        isHolding = true;
                    }
                }
            }
        }


        if (other.gameObject.CompareTag("Coal"))
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button0) && whatPlayerIsThis == 1)
            {
                if (!isHolding)
                {
                    if (other.gameObject.CompareTag("Coal"))
                    {
                        obj = other.gameObject;
                        obj.transform.parent = holdingSpot.transform;
                        obj.transform.position = Vector3.Lerp(obj.transform.position, holdingSpot.transform.position, 10 * Time.deltaTime);
                        isHolding = true;
                    }
                }
            }
        }

    }
}
