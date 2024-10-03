using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    DetectHit hitObj;
    
    // this class decides what to do with the player once the death condition is met.
    // right now, I just reset the scene.

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
            // function for debugging, because we don't have all the logic here yet
            Debug.Log("Player Died!");
            SceneManager.LoadScene("FlyingEndlessLevel");
        }
    }
}
