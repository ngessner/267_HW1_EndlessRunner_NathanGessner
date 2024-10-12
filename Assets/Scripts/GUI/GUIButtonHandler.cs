using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonHandler : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void displayMenu()
    {

    }
}
