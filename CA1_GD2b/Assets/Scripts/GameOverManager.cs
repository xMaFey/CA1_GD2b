using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Makes boxes in unity where I type the scene names so I can switch them
    [SerializeField]
    private String gameSceneName = "GameScene";

    [SerializeField]
    private String mainMenuSceneName = "MainMenu";

    // What happens when I click on the buttons in Main Menu
    public void ReStartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
