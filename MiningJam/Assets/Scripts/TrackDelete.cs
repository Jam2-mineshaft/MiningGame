using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDelete : MonoBehaviour
{
    public float despawn_time = 10f;

    GameObject section;

    void Start()
    { 
        section = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destructor")
        {
            Destroy(section);
        }
    }

    IEnumerator DespawnTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
