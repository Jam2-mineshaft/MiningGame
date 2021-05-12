using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject Cart;
    public GameObject CaveDestructor;

    [Header("Game Over Items")]
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public Text winningPlayerText;
    public Text restartText;
    public UnityEngine.Object gameScene;
    public UnityEngine.Object menuScene;
    public bool hasCaveInHappened = false;
    public GameObject player1Particles;
    public GameObject player2Particles;
    GameObject player1;
    GameObject player2;

    public AudioSource bell;
    public AudioSource music;

    private bool game_finished = false;

    string restart;


    /// <summary>
    /// High score stuff
    /// </summary>
    string Jsonfile = "";
    string JsonPath = "";
    allScores HighScores = new allScores();
    bool scores_processed;

    int high_score_pos;

    public InputField name_to_record;
    public Button save_button;
    public Text new_high_score;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
        game_finished = false;


        JsonPath = Application.dataPath + "/StreamingAssets/HighScores.json";

        if (!File.Exists(JsonPath))
        {
            Jsonfile = JsonUtility.ToJson(HighScores);
            File.WriteAllText(JsonPath, Jsonfile);
        }
        else
        {
            Jsonfile = File.ReadAllText(JsonPath);

            HighScores = JsonUtility.FromJson<allScores>(Jsonfile);
        }
    }

    public void EndGame()
    {
        //game_finished = true;

        StartCoroutine(EndDelay());

        //AudioSource audio = GetComponent<AudioSource>();
        bell.Play();
        music.Stop();

        //if (game_finished)
        //{
        player1.GetComponent<Player2movement>().enabled = false;
        player2.GetComponent<Player2movement>().enabled = false;

        gameOverUI.SetActive(true);
        inGameUI.SetActive(false);

        restart = "Press <color=green>'A'</color> to restart\n or \nPress <color=red>'B'</color> to exit to the menu";
        restartText.text = restart;

        if (player1.GetComponent<Mine>().currentGold > player2.GetComponent<Mine>().currentGold) // Player 1 wins
        {
            winningPlayerText.text = "Player 1 Wins!".ToString();
            player1Particles.SetActive(true);

            if (!scores_processed)
            {
                CheckHighScores(player1.GetComponent<Mine>().currentGold);
                scores_processed = true;
            }
            
        }

        if (player2.GetComponent<Mine>().currentGold > player1.GetComponent<Mine>().currentGold) // Player 2 wins
        {
            winningPlayerText.text = "Player 2 Wins!".ToString();
            player2Particles.SetActive(true);

            if (!scores_processed)
            {
                CheckHighScores(player2.GetComponent<Mine>().currentGold);
                scores_processed = true;
            }
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
        //}
    }

    private void Update()
    {
        if(game_finished)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick2Button0)) // A pressed at game over reloads scene
            {
                Debug.Log("A");
                SceneManager.LoadScene(1);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick2Button1)) // B pressed at game over loads menu
            {
                Debug.Log("B");
                SceneManager.LoadScene(0);
            }
        }
    }

    public bool GameFinished()
    {
        return game_finished;
    }

    IEnumerator EndDelay()
    {
        yield return new WaitForSeconds(1.5f);
        game_finished = true;
        hasCaveInHappened = true;
    }

    void CheckHighScores(int score)
    {
        if (HighScores.ScoreList.Count == 0)
        {
            Debug.Log("highscore first set");
            scoreData record = new scoreData();
            record.score = score;
            if (name_to_record.text == null)
            {
                record.name = "Miner";
            }
            else
            {
                record.name = name_to_record.text;
            }
            
            HighScores.ScoreList.Insert(0, record);

            high_score_pos = 0;
            //SaveHighScores();
        }
        else
        {
            for (int i = 0; i < HighScores.ScoreList.Count ; i++)
            {
                if (score >= HighScores.ScoreList[i].score)
                {
                    Debug.Log("highscore beaten");
                    scoreData record = new scoreData();
                    record.score = score;
                    if (name_to_record.text == null)
                    {
                        record.name = "Miner";
                    }
                    else
                    {
                        record.name = name_to_record.text;
                    }
                    HighScores.ScoreList.Insert(i, record);

                    high_score_pos = i;

                    //SaveHighScores();
                    break;
                }
                else
                {
                    high_score_pos = 100;
                }
            }
        }

        Debug.Log(high_score_pos);

        if (high_score_pos > 2)
        {
            name_to_record.gameObject.SetActive(false);
            save_button.gameObject.SetActive(false);
            new_high_score.gameObject.SetActive(false);
        }
        else
        {
            new_high_score.text = "New High Score of " + score;
        }

        
        //foreach (scoreData saved_score in HighScores.ScoreList)
        //{
        //    if (saved_score.score <= score)
        //    {

        //    }
        //}
    }

    public void SaveHighScores()
    {

        HighScores.ScoreList[high_score_pos].name = name_to_record.text;

        Jsonfile = JsonUtility.ToJson(HighScores);

        File.WriteAllText(JsonPath, Jsonfile);




    }

    [Serializable]
    private class allScores
    {
        public List<scoreData> ScoreList = new List<scoreData>();
    }

    [Serializable]
    private class scoreData
    {
        public string name;
        public int score;
    }
}
