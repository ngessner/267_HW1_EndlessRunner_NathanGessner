using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PointHandler pointHandler;
    public TMP_InputField nameInput;

    void Start()
    {
        displayScore();
    }

    private void displayScore()
    {
        scoreText.text = "Score: " + pointHandler.points;
    }

    public void loadHomeScreen()
    {
        // I have to do this because i couldn't figure out how to get my text file to read in webgl
        // this'll bug out the game because it has no respective file pathing.
#if UNITY_EDITOR
        savePoints();
#endif

        SceneManager.LoadScene("HomeScreen");
    }

    // This turns off detect win, so the player can just go and add scores. This 
    // gives the option for scores < 50
    public void loadInfiniteMode()
    {

#if UNITY_EDITOR
        savePoints();
#endif

        SceneManager.LoadScene("InfiniteMode");
    }

    private void savePoints()
    {
        string playerName = nameInput.text;
        pointHandler.savePoints(playerName);
    }
}
