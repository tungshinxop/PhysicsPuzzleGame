using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelUI : MonoBehaviour
{
    public int score;

    public Text scoreText;
    private string scoreToDisplay;
    public Text moveText;
    private string moveToDisplay;

    /// <summary>
    /// this is called in CheckForWin when blue block reaching the check for win trigger.
    /// </summary>
    public GameObject winLevelPanel;
    public GameObject lostLevelPanel;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHighScore();
    }

    void DisplayHighScore()
    {
        //Debug.Log("score" + score);
        score = GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit * 100;
        scoreToDisplay = "Your score: " + score;
        scoreText.text = scoreToDisplay;

        moveToDisplay = "Moves left: " + GameObject.Find("_GameManager").GetComponent<MovementLimit>().moveLimit;
        moveText.text = moveToDisplay;
    }

    public void nextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Front End");
    }

    public void restartLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
