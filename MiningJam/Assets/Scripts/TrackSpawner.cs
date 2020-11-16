using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public GameObject[] generic_section_prefabs;

    public GameObject cave_exit;

    public GameObject flat_land;

    public GameObject mine_cart;

    float section_length = 135f;

    float next_spawn_position = 135f;

    public int level_length = 5;

    int section_number = 1;

    bool exit_spawned = false;

    bool level_finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!level_finished && mine_cart.transform.position.z >= next_spawn_position - (section_length * 3))
        {
            if (level_length >= section_number)
            {
                Instantiate(generic_section_prefabs[Random.Range(0, generic_section_prefabs.Length)], new Vector3(0, 0, next_spawn_position), new Quaternion(0, 0, 0, 0));
                next_spawn_position += section_length;

                section_number++;
            }
            else if (!exit_spawned)
            {
                Instantiate(cave_exit, new Vector3(0, 0, next_spawn_position), new Quaternion(0, 0, 0, 0));
                next_spawn_position += section_length;
                exit_spawned = true;
            }
            else
            {
                Instantiate(flat_land, new Vector3(0, 0, next_spawn_position), new Quaternion(0, 0, 0, 0));
                next_spawn_position += section_length;
                level_finished = true;
            }
            
        }
        
    }
}
