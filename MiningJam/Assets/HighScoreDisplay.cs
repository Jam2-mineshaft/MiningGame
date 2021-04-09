using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class HighScoreDisplay : MonoBehaviour
{
    string Jsonfile = "";
    string JsonPath = "";

    public GameObject first_high_score_name;
    public GameObject first_high_score_score;

    public GameObject second_high_score_name;
    public GameObject second_high_score_score;

    public GameObject third_high_score_name;
    public GameObject third_high_score_score;

    allScores HighScores = new allScores();

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        if (HighScores.ScoreList.Count > 0)
        {
            first_high_score_name.GetComponent<Text>().text = HighScores.ScoreList[0].name;
            first_high_score_score.GetComponent<Text>().text = HighScores.ScoreList[0].score.ToString();
        }

        if (HighScores.ScoreList.Count > 1)
        {
            second_high_score_name.GetComponent<Text>().text = HighScores.ScoreList[1].name;
            second_high_score_score.GetComponent<Text>().text = HighScores.ScoreList[1].score.ToString();
        }

        if (HighScores.ScoreList.Count > 2)
        {
            third_high_score_name.GetComponent<Text>().text = HighScores.ScoreList[2].name;
            third_high_score_score.GetComponent<Text>().text = HighScores.ScoreList[2].score.ToString();
        }
    }

    private void Awake()
    {
        Jsonfile = JsonUtility.ToJson(HighScores);
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
