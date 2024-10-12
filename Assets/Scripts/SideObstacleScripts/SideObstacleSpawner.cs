using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// issue with this script is i cant have multiple objects spawned at once. 
// I could just apply the translate to a position rather then in update i think
// or use a list to store current obstacles

public class SideObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform[] spawnPos;
    public GameObject currentObstacle;

    public float spawnMin = 3f; 
    public float spawnMax = 8f; 
    public float translateSpeed = 2f; 
    public float destroyOffScreen = 8f; 
    private float spawnTime;

    // swapped prefabs and still having local coordinate issues... not sure how to fix this so ill have to do this.
    private string currentDirection;

    void Start()
    {       
        spawnTime = Random.Range(spawnMin, spawnMax);
    }

    void Update()
    {
        trackTime();
        // moves current obby
        moveObject();
    }

    private void trackTime()
    {
        // Countdown to the next spawn
        spawnTime -= Time.deltaTime;

        // Check if it's time to spawn a new obstacle
        if (spawnTime <= 0f)
        {
            spawnObstacle();
            // Reset the spawn time to a new random delay
            spawnTime = Random.Range(spawnMin, spawnMax);
        }
    }

    private void spawnObstacle()
    {
        // get index
        int obbyI = Random.Range(0, obstacles.Length);
        GameObject selectedObstacle = obstacles[obbyI];

        // Randomly select a spawn position from the array
        int posI = Random.Range(0, spawnPos.Length);
        // store tjat transforms pos
        Transform spawnLocation = spawnPos[posI];

        // store spawn pos
        Vector2 spawnPosition = spawnLocation.position;

        // instantiate
        currentObstacle = Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);

        // reaaaally bad code, would never actually do this, my brain is fried right now though.
        // when i rotate the prefab, it changes its local direction. But its weird because i called vec2.down prior to rotating it
        // so its local positioning shouldn't be bugged? (because its in update?)
        if (spawnLocation.name == "pointL")
        {
            // not gonna use a bool for this 
            currentDirection = "right";
            currentObstacle.transform.Rotate(0, 0, -90); 
        }
        else if (spawnLocation.name == "pointR")
        {
            currentDirection = "left";
            currentObstacle.transform.Rotate(0, 0, 90);
        }
    }

    private void moveObject()
    {
        if (currentObstacle != null)
        {
            // both down direction, this is a stupid workaround for this bug, but its a prefab issue. Vector2.down would work fine if my 
            // prefabs 
            if (currentDirection == "right")
            {
                currentObstacle.transform.Translate(Vector2.right * translateSpeed * Time.deltaTime); 
            }
            else if (currentDirection == "left")
            {
                currentObstacle.transform.Translate(Vector2.left * translateSpeed * Time.deltaTime); 
            }

            Destroy(currentObstacle, destroyOffScreen);
        }
    }
}

