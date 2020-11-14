using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    //starts at 0
    public float fuel = 0.0f;
    public float weight = 0.0f;

    public float weight_side_A = 0.0f;
    public float weight_side_B = 0.0f;

    public LayerMask resourceLayer;

    public Collider side_A_area;
    public Collider side_B_area;


    private void GetWeight()
    {
        Collider[] objectsSideA = Physics.OverlapBox(side_A_area.bounds.center, side_A_area.bounds.extents, side_A_area.transform.rotation, resourceLayer);
        Collider[] objectsSideB = Physics.OverlapBox(side_B_area.bounds.center, side_B_area.bounds.extents, side_B_area.transform.rotation, resourceLayer);

        for (int i = 0; i < objectsSideA.Length; i++)
        {

        }
        for (int i = 0; i < objectsSideB.Length; i++)
        {

        }
    }

}
