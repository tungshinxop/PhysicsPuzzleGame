using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
Create limit for player movement, when movement exceed the limit, reset the game
This script is called in the _GameManager 
*/


public class MovementLimit : MonoBehaviour
{
    public Text moveInGameText;
    private string moveInGameToDisplay;

    //Instiantate limit for movement
    //this int is called in LerpMove in _PlayerManager
    //when player move, minus moveLimit by 1
    public int moveLimit;

    //Setting the move limit at the start of a level
    public void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            moveLimit = 15;
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            moveLimit = 25;
        }

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            moveLimit = 40;
        }

        if (SceneManager.GetActiveScene().name == "Level4")
        {
            moveLimit = 35;
        }

        if (SceneManager.GetActiveScene().name == "Level5")
        {
            moveLimit = 40;
        }
    }

    private void Update()
    {
        MoveInGame();
        LimitReached();
    }
    //called in update()
    void MoveInGame()
    {
            //Displaying move in the game
            moveInGameToDisplay = "Moves left: " + moveLimit;
            moveInGameText.text = moveInGameToDisplay;
    }

    //called in update()
    void LimitReached()
    {
        //check the move limit
        //if move limit less than zero
        //trigger lost screen
        if(moveLimit <= 0)
        {
            GameObject.Find("_CheckWin").GetComponent<CheckForWin>().LevelLost();
            Time.timeScale = 0f;
        }
    }
}
