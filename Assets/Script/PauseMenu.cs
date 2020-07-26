using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Creator: Tung
/// Date created: 23/11/2019
/// Purpose: this script responsible for executing function based on button pressed
/// This script is held in PauseMenuCanvas
/// </summary>
public class PauseMenu : MonoBehaviour
{
    //This bool is to check the condition when escape is press
    //if true turn off pause menu
    //if false turn on pause menu
    public bool gameIsPaused = false;

    public GameObject PauseMenuUI;

    private void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("paused = " + gameIsPaused);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

    }

    //This function is called in Update() in PauseMenu script
    //This function turn on the canvas for pause menu
    //set bool gameIsPause to true
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        //Pause the time in the game
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    //This function is called in Update() in PauseMenu script and Resume button
    //This function turn off pause menu and return to game
    //set bool gameIsPause to false
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        //Set time in game to normal
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    //Called in Update()
    //and Menu button in canvas
    //return to the menu screen
    public void returnToMenu()
    {
        Debug.Log("menu");
        SceneManager.LoadScene("Front End");
        //Set time in game to normal
        Time.timeScale = 1f;
    }

    //Called in Update()
    //and Quit button in canvas
    //Quit the game
    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    //Called in Update()
    //and Restart button in canvas
    //reload the level

    public void Restart()
    {

        PauseMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
