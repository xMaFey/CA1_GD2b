using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // Variable moveSpeed = how fast will the player move
    public float moveSpeed = 5F;

    // Create variables for objects so I can get them in awake function
    private Rigidbody2D rb;
    private Animator anim;

    // Vector for walk movement
    private Vector2 movement;

    // Vector for last move direction (idle) movement
    private Vector2 lastMoveDirection;

    // Variable canMove - I use false and true to lock and unlock the movement of the player
    bool canMove = true;

    [SerializeField] SwordAttack swordAttack;

    [SerializeField] private float health = 10;

    [SerializeField] private TMP_Text displayHealth;

    public float Health
    {
        set
        {
            health = value;
            displayHealth.text = "Health: " + value;
        }

        get
        {
            return health;
        }
    }

    void Start()
    {
        displayHealth.text = "Health: " + health;
    }

    // Get access to Animator and Rigidbody in unity before first frame
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    // In update I put other things than the player movement
    void Update()
    {
        if(canMove == true)
        {
            Attack();
        }

        FlipSwordHitbox();
    }

    // I put the player movement into the fixed update
    void FixedUpdate()
    {
        if(canMove == true){
            Movement();
        }
    }

    void Movement()
    {
        // This stores the last move direction when I stop moving, I want to be facing the right direction and play the right animation in blend tree IDLE
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && (movement.x != 0 || movement.y != 0))
        {
            lastMoveDirection = movement;
        }

        // Stores location in the Vector2 called movement - this is vector for player movement
        movement.x = moveX;
        movement.y = moveY;

        movement.Normalize();

        // Set parameters to Animator so it knows which animation in the blend tree WALK to run
        anim.SetFloat("Horizontal_Walk", movement.x);
        anim.SetFloat("Vertical_Walk", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        // Set parameters to Animator so it knows which animation in the blend tree IDLE to run
        anim.SetFloat("Horizontal_Idle", lastMoveDirection.x);
        anim.SetFloat("Vertical_Idle", lastMoveDirection.y);

        // Moves the rigid body of the player = moves the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(movement.sqrMagnitude > 0.1)
        {
            AudioManager.audioInstance.PlayFootstepSound();
        }
    }

    // I have collider for sword attack and I am rotating it around a player depending in which direction the player is facing
    // Also give values to SwordAttack script to the attackDirection variable - in which direction the player attacks
    void FlipSwordHitbox(){
        if(movement.x > 0)
        {   
            swordAttack.attackDirection = SwordAttack.AttackDirection.right;
        }
        else if(movement.x < 0)
        {
            swordAttack.attackDirection = SwordAttack.AttackDirection.left;
        }

        if(movement.y > 0)
        {
            swordAttack.attackDirection = SwordAttack.AttackDirection.up;
        }
        else if(movement.y < 0)
        {
            swordAttack.attackDirection = SwordAttack.AttackDirection.down;
        }
    }

    // Plays attack animation when I press space and triggers attack function from SwordAttack script
    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Sword_Attack");
            swordAttack.Attack();
            AudioManager.audioInstance.PlaySwordAttackSound();
        }
        
    }

    // I dont want the player to be moving while attacking and this function calls functions prevents it
    public void EndSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    // Locks the players movement
    public void LockMovement()
    {
        canMove = false;
    }

    // Unlock the players movement
    public void UnlockMovement()
    {
        canMove = true;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        print(health);
        if(Health <= 0)
        {
            anim.SetTrigger("Player_Died");
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            anim.SetTrigger("Player_Hit");
        }
    }
}
