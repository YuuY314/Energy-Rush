using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject optionsScreen;
    public GameObject extrasScreen;

    public void SwitchScreen(string screenName)
    {
        if(screenName == "Start Screen"){
            startScreen.SetActive(true);
            optionsScreen.SetActive(false);
            extrasScreen.SetActive(false);
        } else if(screenName == "Options Screen"){
            startScreen.SetActive(false);
            optionsScreen.SetActive(true);
            extrasScreen.SetActive(false);
        } else if(screenName == "Extras Screen"){
            startScreen.SetActive(false);
            optionsScreen.SetActive(false);
            extrasScreen.SetActive(true);
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
