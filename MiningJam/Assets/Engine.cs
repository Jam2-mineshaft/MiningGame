using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public Cart cart;
    public CoalCollector[] coalCollectors;

    void Awake()
    {
        coalCollectors = this.GetComponentsInChildren<CoalCollector>();
        foreach (CoalCollector cc in coalCollectors)
        {
            cc.engine = this;
        }

        if (cart == null)
        {
            Debug.LogError("Engine not referencing cart.");
        }
    }

    void Update()
    {

    }
}
