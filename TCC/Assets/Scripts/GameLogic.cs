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
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

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

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadAsynchronously(levelName));
    }

    IEnumerator LoadAsynchronously(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
        loadingScreen.SetActive(true);

        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100 + "%";
            yield return null;
        }
    }
}
