using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    // Creates a field in unity where I type the name of the main menu scene
    [SerializeField]
    private String mainMenuName = "MainMenu";

    // Loads the main menu screne
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
    }
}
