using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockSpawn : MonoBehaviour
{
    public GameObject rock;
    public Transform[] rockPositions;

    [SerializeField] float spawnDelay;
    [SerializeField] float destroyDelay;
    private float spawnTime;


    void Start()
    {
        
    }

    void Update()
    {
        trackTime();
    }

    // this will change, it won't spawn on a set delay, but 3 seconds after 
    // a tree or rock obstacle is created. Those will have its own time script
    // to get referenced in here later.
    void trackTime()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnDelay)
        {
            spawnRock();
            spawnTime = 0f;
        }        
    }

    void spawnRock()
    {
        int locationToSpawn = Random.Range(0, rockPositions.Length);

        Transform spawnLocation = rockPositions[locationToSpawn];

        Vector2 spawnPosition = spawnLocation.position;

        GameObject spawnedRock = Instantiate(rock, spawnPosition, Quaternion.identity);

        destroyRock(spawnedRock);
    }

    void destroyRock(GameObject spawnedRock)
    {
        Destroy(spawnedRock, destroyDelay);
    }
}



// get the rock prefab
// get the rock spawner transforms under an array
// instantiate that prefab

// only spawn them AFTER an obstacle has been placed so it 
// can choose a position

// spawn them on a delay after the obstacle places them, like
// 2 seconds? or 3?

// future: either make it a trigger that ignores collisions
// (overlap them over obstacles for visuals)
// or 
// make them spawn opposite of the most recent obstacle spawn location
// it might turn out fine