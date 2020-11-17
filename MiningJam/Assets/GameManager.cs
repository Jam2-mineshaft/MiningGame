using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Cart;
    public GameObject CaveDestructor;

    private bool game_finished = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void EndGame()
    {
        game_finished = true;
    }

    public bool GameFinished()
    {
        return game_finished;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
