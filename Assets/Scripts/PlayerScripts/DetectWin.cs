using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectWin : MonoBehaviour
{
    PointHandler pointHandler;

    private void Start()
    {
        pointHandler = GetComponent<PointHandler>();
    }

    void Update()
    {
        checkWin();
    }

    private void checkWin()
    {
        if (pointHandler.points >= 50) 
        {
            SceneManager.LoadScene("WinScene"); 
        }
    }
}
