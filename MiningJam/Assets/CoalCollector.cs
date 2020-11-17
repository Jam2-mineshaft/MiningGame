using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalCollector : MonoBehaviour
{
    public Engine engine;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coal"))
        {
            engine.cart.AddCoal(other.gameObject);
        }
    }
}
