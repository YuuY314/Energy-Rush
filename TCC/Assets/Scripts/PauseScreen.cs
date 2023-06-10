using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseScreen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void LoadLevel(string levelName)
    {
        if(Time.timeScale <= 0){
            Time.timeScale = 1;
            gameIsPaused = false;
        }
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
