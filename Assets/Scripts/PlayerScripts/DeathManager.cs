using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    DetectHit hitObj;
    public GameOverHandler gameOverHandler; 

    void Start()
    {
        hitObj = GetComponent<DetectHit>();
    }

    void Update()
    {
        deathTempDebug();
    }

    void deathTempDebug()
    {
        if (hitObj.playerDeath)
        {       
            Debug.Log("Player Died!");

            gameOverHandler.showGameOver();          
        }
    }
}
