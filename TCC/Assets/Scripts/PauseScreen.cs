using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseScreen;

    public Player player;

    void Update()
    {
        if(Input.GetButtonDown("Pause")){
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
        player.enabled = true;
    }

    void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        player.enabled = false;
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
