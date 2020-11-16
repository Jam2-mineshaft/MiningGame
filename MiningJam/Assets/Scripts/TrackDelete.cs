using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDelete : MonoBehaviour
{
    public float despawn_time = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DespawnTimer(despawn_time));
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destructor")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DespawnTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
