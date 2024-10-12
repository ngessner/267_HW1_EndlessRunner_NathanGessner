using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneScript : MonoBehaviour
{
    public float moveDistance = 5f; 
    public float moveSpeed = 2f; 

    private float movedDistance = 0f; 

    void Update()
    {
        float dist = moveSpeed * Time.deltaTime;

        if (movedDistance < moveDistance)
        {
            transform.Translate(Vector2.right * dist);
            movedDistance += dist; 
        }
    }
}
