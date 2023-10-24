using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    // Variables for settings, which prefab it is going to spawn, how much the spawn rate will be and how much spawnpoints I have (I can add spawnpoint in unity)
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 2F;
    [SerializeField] private Transform[] spawnPoints;

    // Variables for limits - max Enemies I can spawn and current enemies that are spawned
    [Header("Limit Settings")]
    [SerializeField] private int maxEnemies = 5;
    private int currentEnemies = 0;

    public GameObject player;

    private float slimeKilled = 0;

    [SerializeField] private TMP_Text displaySlimeKilled;

    public float SlimeKilled
    {
        set
        {
            slimeKilled = value;
            displaySlimeKilled.text = "Kills: " + slimeKilled;
        }

        get
        {
            return slimeKilled;
        }
    }

    // I call a function which works like a loop for the whole game in the start, it will be spawning the enemies every spawnRate seconds (depends on how much I will put in spawnrate)
    void Start()
    {
        displaySlimeKilled.text = "Kills: " + slimeKilled;
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }

    // If there are less enemies as the max number of enemies, it will spawn an enemy, it will spawn him at random spawner (which I created in unity)
    // It will spawn a prefab of enemy slime and it call a function from Enemy script Initialize which will give the correct properties to the spawned prefab everytime it spawns
    // It sets the current enemies counter to +1
    void SpawnEnemy()
    {
        if(currentEnemies >= maxEnemies) return;
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        Enemy enemy = spawnedEnemy.GetComponent<Enemy>();
        enemy.Initialize(this, player);

        AudioManager.audioInstance.PlaySlimeSpawnSound();

        currentEnemies++;
    }

    // Sets the current enemies counter to -1
    public void EnemyDied()
    {   
        SlimeKilled++;
        currentEnemies--;
    }
}