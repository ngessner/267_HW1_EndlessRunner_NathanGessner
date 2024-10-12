using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public GameObject gameOverGUI; 
    public GameObject normalGUI; 
    public TMP_InputField nameInput;
    public TextMeshProUGUI scoreText;
    public PointHandler pointHandler; 

    private int usersScore;

    private void Start()
    {
        // disable it on start
        gameOverGUI.SetActive(false);
    }

    public void showGameOver()
    {
        // get the score from the point handler, we can show it in here.
        usersScore = pointHandler.points;

        scoreText.text = "Score: " + usersScore;
        gameOverGUI.SetActive(true);
        // turn GUI off.
        normalGUI.SetActive(false);

        stopGame();
    }

    public void passName()
    {
        // get player name
        string pName = nameInput.text; 

        // pass it the player name, it'll save everything on its end.
        pointHandler.savePoints(pName);

        // reset the field, just letting the user know its all good.
        nameInput.text = "";
    }

    public void loadHomeScreen()
    {
        // load home screen
        SceneManager.LoadScene("HomeScreen");
    }
    private void stopGame()
    {
        Time.timeScale = 0; 
    }
}
