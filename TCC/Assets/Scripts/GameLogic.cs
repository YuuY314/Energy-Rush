using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public float timer;
    private int newTime;
    public Text timerText;

    public SpriteRenderer playerSr;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime;
            newTime = (int) timer;
            UpdateTimerText();

            if(newTime == 0){
                playerSr.flipY = true;
            } else {
                playerSr.flipY = false;
            }
        }
    }

    public void UpdateTimerText()
    {
        timerText.text = newTime.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
