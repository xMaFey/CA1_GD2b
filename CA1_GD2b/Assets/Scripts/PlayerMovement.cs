using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5F;
    public Rigidbody2D rb;
    public Animator anim;

    // Vector for walk movement
    private Vector2 movement;

    // Vector for last move (idle) movement
    private Vector2 lastMoveDirection;

    void Start()
    {
        anim = GetComponent<Animator>();

    }
    
    // Called once per frame
    void Update()
    {
        // Store last move direction when stop moving
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && (movement.x != 0 || movement.y != 0))
        {
            lastMoveDirection = movement;
        }

        // Stores location in the Vector2 movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();


        // Set Animators parameters
        anim.SetFloat("Horizontal_Walk", movement.x);
        anim.SetFloat("Vertical_Walk", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        anim.setFloat("Horizontal_Idle", lastMoveDirection.x);
        anim.setFloat("Vertical_Idle", lastMoveDirection.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
