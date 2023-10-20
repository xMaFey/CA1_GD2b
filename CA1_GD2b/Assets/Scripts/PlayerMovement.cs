using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5F;
    private Rigidbody2D rb;
    private Animator anim;

    // Vector for walk movement
    private Vector2 movement;

    // Vector for last move direction (idle) movement
    private Vector2 lastMoveDirection;

    bool canMove = true;

    [SerializeField] SwordAttack swordAttack;

    // Get access to Animator and Rigidbody in unity before first frame
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    
    // Called once per frame
    void Update()
    {
        Attack();
        FlipSwordHitbox();
    }

    void FixedUpdate()
    {
        if(canMove == true){
            Movement();
        }
    }

    void Movement()
    {
        // Store last move direction when I stop moving
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && (movement.x != 0 || movement.y != 0))
        {
            lastMoveDirection = movement;
        }

        // Stores location in the Vector2 called movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        // Set Animators parameters
        anim.SetFloat("Horizontal_Walk", movement.x);
        anim.SetFloat("Vertical_Walk", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        anim.SetFloat("Horizontal_Idle", lastMoveDirection.x);
        anim.SetFloat("Vertical_Idle", lastMoveDirection.y);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void FlipSwordHitbox(){
        if(movement.x > 0)
        {   
            swordAttack.attackDirection = SwordAttack.AttackDirection.right;
            print(swordAttack.attackDirection);
        }
        else if(movement.x < 0)
        {
            swordAttack.attackDirection = SwordAttack.AttackDirection.left;
            print(swordAttack.attackDirection);
        }
    }

    // Play attack animation while I press space
    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Sword_Attack");
            swordAttack.Attack();
            print("Attack!");
        }
        
    }

    // Locks movement while player attacks
    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
