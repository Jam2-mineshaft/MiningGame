using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    GameObject cart;

    bool tut_complete;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        cart.GetComponent<AudioSource>().volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tut_complete)
        {

            if (Input.GetKeyDown(KeyCode.Joystick1Button0)
                || Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                Time.timeScale = 1f;
                gameObject.SetActive(false);
                cart.GetComponent<AudioSource>().volume = 1f;
                tut_complete = true;
            }
        }

    }
}
