using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject start;
    public GameObject option;
    public GameObject highscore;
    public GameObject quit;
    public int Selection = 0;

    void GetInput()
    {
        if (Input.GetAxis("P1-leftjoyverti") >= 0.5)
        {
            Debug.Log("down");
            Selection++;
            if (Selection >= 5)
            {
                Selection = 1;
            }
            ChangeAlpha();

        }
        if (Input.GetAxis("P1-leftjoyverti") <= -0.5)
        {
            Debug.Log("up");
            Selection--;
            if (Selection <= 0)
            {
                Selection = 5;
            }
            ChangeAlpha();

        }
    }

    void ChangeAlpha()
    {
        if (Selection == 1)
        {
           start.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
           option.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
           quit.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        else if(Selection == 2)
        {
            start.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            option.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
            highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        else if(Selection == 3)
        {
            option.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
            quit.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        else if(Selection == 4)
        {
            start.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            quit.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        GetInput();
    }
}
