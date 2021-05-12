using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							 
	public GameObject optionsTint;							
	public GameObject menuPanel;							 
	public GameObject pausePanel;

	public GameObject scoresPanel;
	public GameObject scoresTint;

	public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	public void ShowScorePanel()
	{
		scoresPanel.SetActive(true);
		scoresTint.SetActive(true);
	}

	public void HideScorePanel()
	{
		scoresPanel.SetActive(false);
		scoresTint.SetActive(false);
	}

	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);
	}
}
