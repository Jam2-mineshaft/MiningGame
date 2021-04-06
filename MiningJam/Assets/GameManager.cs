using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Cart;
    public GameObject CaveDestructor;

    [Header("Game Over Items")]
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public Text winningPlayerText;
    public Text restartText;
    public Object gameScene;
    public Object menuScene;
    public bool hasCaveInHappened = false;
    public GameObject player1Particles;
    public GameObject player2Particles;
    GameObject player1;
    GameObject player2;

    public AudioSource bell;
    public AudioSource music;

    private bool game_finished = false;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
    }

    public void EndGame()
    {
        game_finished = true;

        //AudioSource audio = GetComponent<AudioSource>();
        bell.Play();
        music.Stop();

        if (game_finished)
        {
            player1.GetComponent<Player2movement>().enabled = false;
            player2.GetComponent<Player2movement>().enabled = false;

            gameOverUI.SetActive(true);
            inGameUI.SetActive(false);

            string restart = "Press <color=green>'A'</color> to restart\n or \nPress <color=red>'B'</color> to exit to the menu";
            restartText.text = restart;

            if(player1.GetComponent<Mine>().currentGold > player2.GetComponent<Mine>().currentGold) // Player 1 wins
            {
                winningPlayerText.text = "Player 1 Wins!".ToString();
                player1Particles.SetActive(true);
            }

            if (player2.GetComponent<Mine>().currentGold > player1.GetComponent<Mine>().currentGold) // Player 2 wins
            {
                winningPlayerText.text = "Player 2 Wins!".ToString();
                player2Particles.SetActive(true);
            }

            if (player1.GetComponent<Mine>().currentGold == player2.GetComponent<Mine>().currentGold && !hasCaveInHappened) // Draw
            {
                winningPlayerText.text = "It's a Draw!".ToString();
                player1Particles.SetActive(true);
                player2Particles.SetActive(true);
            }

            if (hasCaveInHappened) // Cave in occured
            {
                winningPlayerText.text = "Everyone's a Loser!".ToString();
            }
        }
    }

    private void Update()
    {
        if(game_finished)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick2Button0)) // A pressed at game over reloads scene
            {
                Debug.Log("A");
                SceneManager.LoadScene(gameScene.name);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick2Button1)) // B pressed at game over loads menu
            {
                Debug.Log("B");
                SceneManager.LoadScene(menuScene.name);
            }
        }
    }

    public bool GameFinished()
    {
        return game_finished;
    }
}
