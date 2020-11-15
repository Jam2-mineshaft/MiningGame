using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public GameObject[] generic_section_prefabs;

    public GameObject mine_cart;

    float section_length = 135f;

    float next_spawn_position = 135f;

    //private CaveManager caveManager;
    //public List<GameObject> sections;

    //public List<GameObject> prefabPool = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
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
        if (mine_cart.transform.position.z >= next_spawn_position - (section_length * 3))
        {
            Instantiate(generic_section_prefabs[Random.Range(0, generic_section_prefabs.Length)], new Vector3(0, 0, next_spawn_position), new Quaternion(0, 0, 0, 0));
            next_spawn_position += section_length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Section_Detection"))
        {

        }
    }
}
