using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class StartOptions : MonoBehaviour
{



	public int sceneToStart = 1;                                        
	public bool changeScenes;                                           
	public bool changeMusicOnStart;                                     
	public int musicToChangeTo = 0;                                   


	[HideInInspector] public bool inMainMenu = true;                   
	[HideInInspector] public Animator animColorFade;                    
	[HideInInspector] public Animator animMenuAlpha;                    
	[HideInInspector] public AnimationClip fadeColorAnimationClip;     
	[HideInInspector] public AnimationClip fadeAlphaAnimationClip;      


	private PlayMusic playMusic;                                      
	private float fastFadeIn = .01f;                                    
	private ShowPanels showPanels;                                    


	void Awake()
	{
		showPanels = GetComponent<ShowPanels>();

		playMusic = GetComponent<PlayMusic>();
	}


	public void StartButtonClicked()
	{
		if (changeScenes)
		{
			Invoke("LoadDelayed", fadeColorAnimationClip.length * .5f);

			animColorFade.SetTrigger("fade");
		}

		else
		{
			StartGameInScene();
		}

	}


	public void LoadDelayed()
	{
		inMainMenu = false;

		showPanels.HideMenu();

		Application.LoadLevel(sceneToStart);
	}


	public void StartGameInScene()
	{
		inMainMenu = false;
		animMenuAlpha.SetTrigger("fade");

		Invoke("HideDelayed", fadeAlphaAnimationClip.length);

		SceneManager.LoadScene("Levels");
	}


	public void PlayNewMusic()
	{
		//ADD MUSIC
	}

	public void HideDelayed()
	{
		showPanels.HideMenu();
	}
}
