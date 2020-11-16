using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public GameObject[] generic_section_prefabs;

    public GameObject mine_cart;

    float section_length = 135f;

    float next_spawn_position = 135f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mine_cart.transform.position.z >= next_spawn_position - (section_length * 3))
        {
            Instantiate(generic_section_prefabs[Random.Range(0, generic_section_prefabs.Length)], new Vector3(0, 0, next_spawn_position), new Quaternion(0, 0, 0, 0));
            next_spawn_position += section_length;
        }
    }
}
