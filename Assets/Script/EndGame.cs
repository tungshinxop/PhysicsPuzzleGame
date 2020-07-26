using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is held in the last scene and in the canvas
/// </summary>
public class EndGame : MonoBehaviour
{
    //Load menu scene
    public void BackToMenu()
    {
        SceneManager.LoadScene("Front End");
    }

    //Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}

