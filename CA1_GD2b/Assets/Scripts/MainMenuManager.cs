using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Makes boxes in unity where I type the scene names so I can switch them
    [SerializeField]
    private String gameSceneName = "GameScene";

    [SerializeField]
    private String optionsSceneName = "Options";

    void awake()
    {
        AudioManager.audioInstance.PlayBackgroundMusic();
        AudioManager.audioInstance.SetBackgroundMusicVolume(0.5F);
    }

    // What happens when I click on the buttons in Main Menu
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(optionsSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}