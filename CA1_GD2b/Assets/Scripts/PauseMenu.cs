using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Create gameObject as a screen over the game
    public GameObject pauseMenu;

    // Variable for pause and unpause my game
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // When I press escape the game is going to pause or resume
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                AudioManager.audioInstance.PlayAmbientMusic();
                ResumeGame();
            }
            else
            {
                AudioManager.audioInstance.PauseAmbientMusic();
                PauseGame();
            }
        }
    }

    // Pause game = set variable isPaused to true, so it will pause the game and the time is stop (set to 0)
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0F;
        isPaused = true;
    }

    // Resume game = set variable isPaused to false, so it will resume the game and the time runs normally (is set to 1)
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1F;
        isPaused = false;
    }

    // Switches scenes to main menu and runs the time - sets the time to 1 again
    public void GoToMainMenu()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene("MainMenu");
    }

    // Quits the app
    public void QuitGame()
    {
        Application.Quit();
    }
}
