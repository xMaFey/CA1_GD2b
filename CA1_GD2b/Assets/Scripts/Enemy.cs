using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 1;

    private EnemySpawner spawner;
    private Animator anim;
    public float moveSpeed = 3F;

    private Vector2 enemyMovement;
    private Rigidbody2D rb;
    public Rigidbody2D player;

    public void Initialize(EnemySpawner spawnerReference)
    {
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
    }

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

    void Die()
    {
        if(spawner != null)
        {
            spawner.EnemyDied();
        }
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        print(health);
        if(health <= 0)
        {
            anim.SetTrigger("Slime_Died");
        }
        else
        {
            anim.SetTrigger("Slime_Damaged");
        }
    }
}
