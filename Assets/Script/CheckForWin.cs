using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Date created: 18/11/2019
Creator: Tung
Purpose: Change to a another level/scene when winning condition is met or restart the level
This script is held in _CheckWin which is the child of _GameManager in the hierarchy
*/
public class CheckForWin : MonoBehaviour
{
    //[SerializeField] 
    public bool checkingWinningCondition = false;

    private CameraFollow cameraFollowScript;

    public bool isWon = true;
    //public AudioClip explosion;

    public float restartTime = 1f;

    public GameObject inGameCanvas;

    private void Start()
    {
        cameraFollowScript = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    void Update()
    {
        TriggerWin();
    }

    //This function check if ObjectiveBlock is touching Goal floor
    //if it is touch set checkingWinningCondition to true
    //if not set checkingWinningCondition to false
    //Called in Update()
    void TriggerWin()
    {
        if (cameraFollowScript.isFallingWon == true)
        {
            checkingWinningCondition = true;
            //nextLevel();
            //isWon = true;
            //Debug.Log("Won");   
        }
        else
        {
            checkingWinningCondition = false;
            //Debug.Log("Lost");
        }
    }


    //These function check the bool checkingWinningCondition
    //if it is true open winning screen and change to another scene
    //if it is false display losing screen and restart level

    //bool isWon is set to true if level won
    //false if level lost

    /// <summary>
    /// if isWon = false : turn on the explosion sound effect in the script that is held in MainCamera
    /// if true do nothing
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "objectiveBlock" && checkingWinningCondition == true)
        {
            LevelWon(); 
        }

        if (collision.gameObject.tag == "objectiveBlock" && checkingWinningCondition == false)
        {
            LevelLost();
            
        }

        if (collision.gameObject.tag == "playerBlock")
        {
            LevelLost(); 
        }

    }


    public void LevelLost()
    {
        Debug.Log("You lose");
        GameObject.Find("EndLevelCanvas").GetComponent<EndLevelUI>().lostLevelPanel.SetActive(true);
        //Destroy(this.gameObject);
        //Restart();
        //Invoke("Restart", restartTime); //Invoke will call out the function after restartTime
        isWon = false;
        inGameCanvas.SetActive(false);
    }

    public void LevelWon()
    {
        //Debug.Log("You win");
        //Turn on the end menu UI
        GameObject.Find("EndLevelCanvas").GetComponent<EndLevelUI>().winLevelPanel.SetActive(true);
        //NextLevel();
        Destroy(this.gameObject);
        isWon = true;
        inGameCanvas.SetActive(false);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel()
    {
        //if (SceneManager.GetActiveScene().name == "Level1")
        //{
        //    SceneManager.LoadScene("Level2");
        //}

        //if (SceneManager.GetActiveScene().name == "Level2")
        //{
        //    SceneManager.LoadScene("Level3");
        //}

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
