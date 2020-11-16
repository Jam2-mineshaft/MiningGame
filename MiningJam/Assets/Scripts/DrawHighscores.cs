using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHighscores : MonoBehaviour
{
    public TextAsset jsonFile;
    private int[] scores;


    void Start()
    {
        string json = file.ReadToEnd();
        List<Item> score = JsonConvert.DeserializeObject<List<Item>>(json);

        /*for (int i = 0; i < 5; i++)
        {
            scores[i] = JsonUtility.FromJson<scores>(jsonFile.text);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
