using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWIn : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart_Destructor"))
        {
            gameManager.EndGame();
            gameManager.Cart.GetComponent<CartMovement>().StopCart();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
