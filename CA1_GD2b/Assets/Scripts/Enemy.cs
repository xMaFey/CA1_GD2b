using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 1;

    private EnemySpawner spawner;

    public void Initialize(EnemySpawner spawnerReference)
    {
        print("initializeSpawner");
        spawner = spawnerReference;
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
            Die();
        }
    }
}
