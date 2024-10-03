using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    // don't need move y for this game.
    private float moveX;
    

    void Start()
    {
        // reference rb
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        // get axis raw returns either 1 or 0 from the input systems horizontal logic,
        // and is stored in moveX
        moveX = Input.GetAxisRaw("Horizontal");

        // move at input systems directed moveX, multiplied by moveSpeed. Keep the normal y velocity position (whatever its at basically)
        rb.velocity = new Vector2(moveSpeed * moveX, rb.velocity.y);
    }
}


// we want to move left, and right. 
// We want that controlled by a set movespeed 
