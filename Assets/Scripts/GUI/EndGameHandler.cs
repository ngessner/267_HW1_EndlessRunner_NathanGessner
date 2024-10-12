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
        string playerName = nameInput.text;
        pointHandler.savePoints(playerName);

        SceneManager.LoadScene("HomeScreen");      
    }
    // this turns off detect win, so the player can just go and add scores. This 
    // gives the option for scores < 50
    public void loadInfiniteMode()
    {
        string playerName = nameInput.text;
        pointHandler.savePoints(playerName);

        SceneManager.LoadScene("InfiniteMode");
    }
}
