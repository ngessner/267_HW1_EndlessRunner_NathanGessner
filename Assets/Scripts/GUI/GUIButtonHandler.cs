using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonHandler : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("FlyingEndlessLevel");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void loadLeadboardsMenu()
    {    
        SceneManager.LoadScene("Leaderboards");
    }
    public void loadHomeScreen()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
