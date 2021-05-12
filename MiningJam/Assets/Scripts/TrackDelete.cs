using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDelete : MonoBehaviour
{
    GameObject section;

    // Start is called before the first frame update
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
}
