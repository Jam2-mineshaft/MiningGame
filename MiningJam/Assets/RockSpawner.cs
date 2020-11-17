using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    GameManager gameManager;

    public GameObject rock_prefab;

    private List<GameObject> rocks;

    int num_rocks = 30;

    public float rock_range = 12.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rocks = new List<GameObject>();
    }

    public IEnumerator SpawnRocks()
    {
        print("test");

        float margins = rock_range / 2;

        for (int i = 0; i < num_rocks; i++)
        {
            print("test");
            Vector3 pos = new Vector3(Random.Range(transform.position.x - margins, transform.position.x + margins), transform.position.y, Random.Range(transform.position.z - margins, transform.position.z + margins));
            Quaternion rotation = new Quaternion();

            rotation.Set(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 1);

            GameObject go = Instantiate(rock_prefab, pos, rotation) as GameObject;

            yield return new WaitForSeconds(Random.Range(0, 0.5f));
        }

        DestructorMovement dm = gameManager.CaveDestructor.GetComponent<DestructorMovement>();
        dm.DisableDestructor();
    }

    IEnumerator wait()
    {
        bool test = false;
        yield return new WaitForSeconds(Random.Range(0, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
