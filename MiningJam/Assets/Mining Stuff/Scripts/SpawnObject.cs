using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject coal;
    public GameObject gold;
    public GameObject spawnPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(coal, spawnPoint.transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(gold, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
