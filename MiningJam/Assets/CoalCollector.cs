using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalCollector : MonoBehaviour
{
    public Engine engine;

    public Transform player1Holder;
    public Transform player2Holder;

   [SerializeField] PickUpObject player1;
   [SerializeField] PickUpObject player2;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1").GetComponent<PickUpObject>();
        player2 = GameObject.FindGameObjectWithTag("Player 2").GetComponent<PickUpObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coal"))
        {
            engine.cart.AddCoal(other.gameObject);

            if(other.transform.parent == player1Holder)
            {
                player1.isHolding = false;
            }

            if(other.transform.parent == player2Holder)
            {
                player2.isHolding = false;
            }
        }
    }
}
