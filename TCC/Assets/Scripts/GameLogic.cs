using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public float battery;
    private int batteryLimit = 900;
    private int newBattery;
    public Slider batteryBar;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(battery > 0){
            battery -= Time.deltaTime;
            newBattery = (int) battery;
            UpdateBatteryBar();
        }
    }

    public void UpdateBatteryBar()
    {
        if(battery <= batteryLimit){
            batteryBar.value = newBattery;
        } else {
            batteryBar.value = batteryLimit;
            battery = batteryLimit;
            newBattery = batteryLimit;
        }
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
