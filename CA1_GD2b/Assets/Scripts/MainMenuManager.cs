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

    // void awake()
    // {
    //     backgroundMusicSource = gameObject.AddComponent<AudioSource>();

    //     backgroundMusicSource.clip = backgroundMusic;
    //     backgroundMusicSource.loop = true;
    //     backgroundMusicSource.Play();
    // }

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