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
        AudioManager.audioInstance.PlayBackgroundMusic();
        AudioManager.audioInstance.SetBackgroundMusicVolume(0.1F);
        SceneManager.LoadScene("GameOver");
    }

    // Restarts the game
    public void RestartGame()
    {
        AudioManager.audioInstance.PlayAmbientMusic();
        AudioManager.audioInstance.SetAmbientMusicVolume(1F);
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        AudioManager.audioInstance.PlayBackgroundMusic();
        AudioManager.audioInstance.SetBackgroundMusicVolume(0.5F);
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenOptions()
    {
        AudioManager.audioInstance.PlayBackgroundMusic();
        AudioManager.audioInstance.SetBackgroundMusicVolume(0.5F);
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
