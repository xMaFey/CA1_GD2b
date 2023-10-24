using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 6F;

    [SerializeField] private float moveSpeed = 1F;

    [SerializeField] private float slimeDamage = 1F;

    [SerializeField] private float attackCooldown = 0.3F;

    private float lastAttack = 0.3F;

    // Creates variables for objects so I can get them in awake and start function
    private EnemySpawner spawner;
    private Animator anim;
    private Vector2 enemyMovement;
    private Rigidbody2D rb;
    public GameObject player;

    // Variables for health of the slime (setter and getter), I can set the slime HP here and also get from it how many HP the slime has 
    public float Health
    {
        set
        {
            health = value;
        }

        get
        {
            return health;
        }
    }

    // This function works like a loop for things that I wanna be looping whole game
    public void Initialize(EnemySpawner spawnerReference, GameObject player)
    {
        this.player = player;
        print("initializeSpawner");
        spawner = spawnerReference;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        lastAttack += Time.deltaTime;
    }

    // I put all movement functions in fixed update
    void FixedUpdate()
    {
        SlimeMove();
    }

    // This function will get the position of the player and it will set the slime movement to follow the players position
    void SlimeMove()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        rb.MovePosition(transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }

    // Function for slime to die, it will call the function EnemyDied from EnemySpawner script which sets the enemy counter to -1 (or more if I kill more enemies at once)
    // It also destroys the game object
    void Die()
    {
        if(spawner != null)
        {
            spawner.EnemyDied();
        }
        Destroy(gameObject);
    }

    // In this funciton I set how much damage will the player deal to the enemy
    // It counts the damage of the HP of the enemy
    // If the hit sets the enemy HP to 0 or lower, it calls a Die function and the enemydies
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {   
            anim.SetTrigger("Slime_Died");
        }
        else
        {
            anim.SetTrigger("Slime_Damaged");
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {   
            if(lastAttack >= attackCooldown)
            {
                PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
                player.TakeDamage(slimeDamage);
                lastAttack = 0;
            }
        }
    }
}
