using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Runtime.InteropServices;




public class SelectionManager : MonoBehaviour
{
    public GameObject start;
    public GameObject option;
    public GameObject highscore;
    public GameObject quit;
    public GameObject back;
    public GameObject masterUI;

    public Button play;
    public Button Options;
    public Button HighScores;
    public Button Quit;

    public ColorBlock unhighlighted;
    public ColorBlock hightlighted;


    public GameObject sfxSlider;
    public GameObject musicSlider;

    public int Selection = 1;
    public int audioSelection = 3;

    private float change = 5f;
    private float KeyDelay = 0.1f;
    private float timePassed = 0f;

    private bool options = false;
    private bool lockSpeed = false;
    private bool inMenu = true;

    [HideInInspector] public Animator animColorFade;
    [HideInInspector] public Animator animMenuAlpha;
    [HideInInspector] public AnimationClip fadeColorAnimationClip;
    [HideInInspector] public AnimationClip fadeAlphaAnimationClip;

    private ShowPanels showPanels;

    private StartOptions script;
    private StartOptions stsc;
    private QuitApplication qa;
    private ShowPanels sp;

    

    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    void GetInput()
    {
        if (!options)
        {
            if (Input.GetAxis("DPADY") == -1 && CheckDelay())
            {
                Debug.Log("down");
                Selection++;
                if (Selection >= 5)
                {
                    Selection = 1;
                }
                ChangeAlpha();

            }
            if (Input.GetAxis("DPADY") == 1 && CheckDelay())
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

                //Quit.colors = unhighlighted;

                //SetCursorPos(600, 500);
                //Debug.Log((int)start.transform.position.x + (int)start.transform.position.y);
            }
            else if (Selection == 2)
            {
                start.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                option.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 0);

                //SetCursorPos(600,650);
            }
            else if (Selection == 3)
            {
                option.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                quit.GetComponent<Image>().color = new Color32(255, 255, 255, 0);

                //SetCursorPos(600, 800);
            }
            else if (Selection == 4)
            {
                start.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                highscore.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                quit.GetComponent<Image>().color = new Color32(255, 255, 255, 255);


                //Quit.colors = hightlighted;

                SetCursorPos(600, 950);
                
                //SetCursorPos((int)quit.transform.position.x, (int)quit.transform.position.y);
            }
        }
    }

    void UseButton() 
    {
        if (Input.GetButton("Fire1") && CheckDelay())
        {
            if (Selection == 1)
            {
                inMenu = false;
                stsc.StartButtonClicked();
            }
            if (Selection == 2)
            {
                sp.ShowOptionsPanel();
                options = true;
            }
            if (Selection == 3)
            {
                sp.ShowScorePanel();
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
        if (Input.GetAxis("DPADY") == -1 && CheckDelay())
        {
            audioSelection++;
            if (audioSelection >= 4)
            {
                audioSelection = 1;
            }
            Sliders();
        }

        if (Input.GetAxis("DPADY") == 1 && CheckDelay())
        {
            audioSelection--;
            if (audioSelection <= 0 && !lockSpeed)
            {
                audioSelection = 2;
            }
            Sliders();
        }

        if (Input.GetAxis("DPADX") == -1 && CheckDelay())
        {
            if (audioSelection == 1)
            {
                musicSlider.GetComponent<Slider>().value -= change;
            }
            if (audioSelection == 2)
            {
                sfxSlider.GetComponent<Slider>().value -= change;
            }
        }

        if (Input.GetAxis("DPADX") == 1 && CheckDelay())
        {
            if (audioSelection == 1)
            {
                musicSlider.GetComponent<Slider>().value += change;
            }
            if (audioSelection == 2)
            {
                sfxSlider.GetComponent<Slider>().value += change;
            }
        }

        if (Input.GetButtonDown("Fire1") && audioSelection == 3 && CheckDelay())
        {
            sfxSlider.GetComponent<Slider>().image.color = new Color32(255, 255, 255, 255);
            musicSlider.GetComponent<Slider>().image.color = new Color32(255, 255, 255, 255);

            sp.HideOptionsPanel();
            options = false;
        }
    }

    void Sliders()
    {
        if (audioSelection == 1)
        {
            sfxSlider.GetComponent<Slider>().image.color = new Color32(255, 255, 255, 255);
            musicSlider.GetComponent<Slider>().image.color = new Color32(255, 0, 0, 255);
            back.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
        if (audioSelection == 2)
        {
            sfxSlider.GetComponent<Slider>().image.color = new Color32(255, 0, 0, 255);
            musicSlider.GetComponent<Slider>().image.color = new Color32(255, 255, 255, 255);
            back.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
        if (audioSelection == 3)
        {
            sfxSlider.GetComponent<Slider>().image.color = new Color32(255, 255, 255, 255);
            musicSlider.GetComponent<Slider>().image.color = new Color32(255, 255, 255, 255);
            back.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    bool CheckDelay()
    {
        if (timePassed >= KeyDelay)
        {
            timePassed = 0f;
            return true;
        }

        return false;
    }


    void Start()
    {
       script = masterUI.gameObject.GetComponent<StartOptions>();
       stsc = masterUI.GetComponent<StartOptions>();
       qa = masterUI.GetComponent<QuitApplication>();
       sp = masterUI.GetComponent<ShowPanels>();

        Quit = quit.GetComponent<Button>();


        unhighlighted.normalColor = Color.white;
        unhighlighted.highlightedColor = Color.red;
        unhighlighted.pressedColor = Color.white;
        unhighlighted.selectedColor = Color.white;
        unhighlighted.disabledColor = Color.white;

        hightlighted.normalColor = Color.red;
        hightlighted.highlightedColor = Color.red;
        hightlighted.pressedColor = Color.white;
        hightlighted.selectedColor = Color.white;
        hightlighted.disabledColor = Color.white;
    }

    void Update()
    {
        if (inMenu)
        {
            if (!options)
            {
                //GetInput();
                //UseButton();
            }
            else
            {
                //Option();
            }
        }
        timePassed += Time.deltaTime;
    }
}
