using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public CartMovement cart_movement;
    public LayerMask resource_layer;
    public Engine engine;

    public float weight;

    public Collider side_A_area;
    public float player_A_gold;
    public float player_A_weight;

    public Collider side_B_area;
    public float player_B_gold;
    public float player_B_weight;

    public float tilt_bias = 0f;

    private void Start()
    {
        engine = gameObject.GetComponentInChildren<Engine>();
        engine.cart = this;

        if (cart_movement == null)
        {
            Debug.LogError("CartMovement not set up.");
        }
        if (side_A_area == null || side_B_area == null)
        {
            Debug.LogError("Side colliders not assigned.");
        }
    }

    private void Update()
    {
        if (Random.Range(0, 100) < 20)
        {
            CheckGoldAndWeight();
        }
    }

    private void CheckGoldAndWeight()
    {
        Collider[] objectsSideA = Physics.OverlapBox(side_A_area.bounds.center, side_A_area.bounds.extents, side_A_area.transform.rotation, resource_layer);
        Collider[] objectsSideB = Physics.OverlapBox(side_B_area.bounds.center, side_B_area.bounds.extents, side_B_area.transform.rotation, resource_layer);

        weight = objectsSideA.Length + objectsSideB.Length;
        player_A_weight = objectsSideA.Length;
        player_B_weight = objectsSideB.Length;



        int player_A_count = 0;
        int player_B_count = 0;

        for (int i = 0; i < objectsSideA.Length; i++)
        {
            GameObject resource = objectsSideA[i].gameObject;
            if (resource.CompareTag("Gold"))
            {
                player_A_count++;
            }
        }
        for (int i = 0; i < objectsSideB.Length; i++)
        {
            GameObject resource = objectsSideB[i].gameObject;
            if (resource.CompareTag("Gold"))
            {
                player_B_count++;
            }
        }

        player_A_gold = player_A_count;
        player_B_gold = player_B_count;
    }

    private void TiltCart()
    {
        tilt_bias = player_B_weight - player_A_weight;
    }

    //Engine Functinos
    public void AddCoal(GameObject coal)
    {
        cart_movement.AddFuel();
        Destroy(coal);
    }

    public void FuelBellow50()
    { }
    public void FuelBellow30()
    { }

}
