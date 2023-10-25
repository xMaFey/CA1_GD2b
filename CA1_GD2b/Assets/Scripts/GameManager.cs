using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameInstance;

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
        SceneManager.LoadScene("GameOver");
    }

    // Restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
