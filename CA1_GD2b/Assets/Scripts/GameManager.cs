using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameInstance;

    [Header("Game stance")]
    public bool isPaused;
    public bool isGameOver;

    // This wont get destoyed through the game
    void Awake()
    {
        if (gameInstance == null)
        {
         gameInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Game over function
    public void GameOver()
    {
        isGameOver = true;
        // This is where I choose what happens when game is game over
        SceneManager.LoadScene("GameOver");
    }

    // Restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
