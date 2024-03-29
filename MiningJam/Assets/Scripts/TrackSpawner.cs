﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    GameManager gameManager;

    public GameObject[] generic_section_prefabs;

    public GameObject cave_exit;

    public GameObject flat_land;

    public GameObject mine_cart;

    float section_length = 135f;

    float next_spawn_position = 135f;

    public int level_length = 5;

    int section_number = 1;

    bool exit_spawned = false;

    [HideInInspector]
    public bool level_finished = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        /*
        int start_loc = -135;

        sections = new List<GameObject>();

        caveManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CaveManager>();

        for (int i = 0; i < prefabPool.Count; i++)
        {
            sections.Add(GameObject.Instantiate(prefabPool[i]));
            sections[i].transform.Translate(new Vector3(0, 0, start_loc));
            start_loc += 135;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GameFinished())
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
}
