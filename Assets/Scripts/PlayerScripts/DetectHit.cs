using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    // public for menu's later
    [HideInInspector] public bool playerDeath = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if whatever we're colliding with has the tag object
        if (collision.gameObject.CompareTag("Object"))
        {
            playerDeath = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathWall"))
        {
            // if someone manages to clip through somehow, they'll get reset anyways.
            // might be redundant, but the homework required it.
            playerDeath = true;
        }
    }
}
