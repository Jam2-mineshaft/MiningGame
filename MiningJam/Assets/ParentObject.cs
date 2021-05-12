using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObject : MonoBehaviour
{
    private void Start()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Cart").transform);
    }
}
