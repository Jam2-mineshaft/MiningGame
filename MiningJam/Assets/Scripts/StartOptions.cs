using UnityEngine;
using System.Collections;
using UnityEngine.Audio;


public class StartOptions : MonoBehaviour {



	public int sceneToStart = 1;									
	public bool changeScenes;											
	public bool changeMusicOnStart;									
	public int musicToChangeTo = 0;									


	[HideInInspector] public bool inMainMenu = true;				
	


	private PlayMusic playMusic;										
	private float fastFadeIn = .01f;								
	private ShowPanels showPanels;										

	
	void Awake()
	{
		showPanels = GetComponent<ShowPanels> ();

		playMusic = GetComponent<PlayMusic> ();
	}


	public void StartButtonClicked()
	{
		if (changeScenes) 
		{
			//CHANGE SCENE FROM START MENU
		} 

		else 
		{
			StartGameInScene();
		}

	}


	public void LoadDelayed()
	{
		inMainMenu = false;

		showPanels.HideMenu ();

		Application.LoadLevel (sceneToStart);
	}


	public void StartGameInScene()
	{
		inMainMenu = false;

		//CHANGE SCENE WHEN START PRESS
	}


	public void PlayNewMusic()
	{
		//CHANGE MUSIC TO BE ADDED
	}

	public void HideDelayed()
	{
		showPanels.HideMenu();
	}
}
