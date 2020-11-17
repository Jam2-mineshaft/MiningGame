using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectionManager : MonoBehaviour
{
    public GameObject start;
    public GameObject option;
    public GameObject highscore;
    public GameObject quit;
    public GameObject masterUI;

    public GameObject sfxSlider;
    public GameObject musicSlider;

    public int Selection = 0;
    public int audioSelection = 1;

    private bool options = false;

    [HideInInspector] public Animator animColorFade;
    [HideInInspector] public Animator animMenuAlpha;
    [HideInInspector] public AnimationClip fadeColorAnimationClip;
    [HideInInspector] public AnimationClip fadeAlphaAnimationClip;

    private ShowPanels showPanels;

    StartOptions script;
    StartOptions stsc;
    QuitApplication qa;
    ShowPanels sp;

    void CheckInMenu()
    {
        script = masterUI.gameObject.GetComponent <StartOptions> ();

        if (script.inMainMenu = true)
        {
            GetInput();
        }
    }

    void GetInput()
    {
        if (!options)
        {
            if (Input.GetAxis("DPAD") == -1)
            {
                Debug.Log("down");
                Selection++;
                if (Selection >= 5)
                {
                    Selection = 1;
                }
                ChangeAlpha();

            }
            if (Input.GetAxis("DPAD") == 1)
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
    }

    void ChangeAlpha()
    {
        if (!options)
        {
            if (Selection == 1)
            {
                start.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                option.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                quit.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
            else if (Selection == 2)
            {
                start.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                option.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
            else if (Selection == 3)
            {
                option.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                quit.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
            else if (Selection == 4)
            {
                start.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                quit.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }

    void UseButton() 
    {
        if (Input.GetButton("Fire1") && !options)
        {
            if (Selection == 1)
            {
                stsc.StartButtonClicked();
            }
            if (Selection == 2)
            {
                sp.ShowOptionsPanel();
                options = true;
            }
            if (Selection == 4)
            {
                qa.Quit();
            }
        }
    }

    void Option()
    {
        if (Input.GetAxis("DPAD") == -1)
        {
            audioSelection++;
            if (Selection >= 3)
            {
                Selection = 1;
            }
            Sliders();
        }

        if (Input.GetAxis("DPAD") == 1)
        {
            Selection--;
            if (Selection <= 0)
            {
                Selection = 2;
            }
        }
    }

    void Sliders()
    {
        sfxSlider.GetComponent<Slider> = new Color32(255, 0, 0, 0);
    }

    void Start()
    {
       stsc = masterUI.GetComponent<StartOptions>();
       qa = masterUI.GetComponent<QuitApplication>();
       sp = masterUI.GetComponent<ShowPanels>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!options)
        {
            CheckInMenu();
            UseButton();
        }
        else
        {
            Option();
        }
    }
}
