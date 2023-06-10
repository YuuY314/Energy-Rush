using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public float battery;
    public int batteryLimit = 300;
    private int newBattery;
    public Slider batteryBar;
    public Image batteryBarColor;

    public int rustyGears;
    public int normalGears;
    public int stainlessGears;

    // public GameObject loadingScreen;
    // public Slider slider;
    // public Text progressText;

    public GameObject gameOverScreen;
    
    public AudioSource gearSFX;

    void Start()
    {
        instance = this;
        battery = (float) batteryLimit;
    }

    void Update()
    {
        UpdateBattery();
    }

    public void UpdateBattery()
    {
        if(battery > 0){
            battery -= Time.deltaTime;
            newBattery = (int) battery;
            UpdateBatteryBar();

            Color green = new Color(0f, 1f, 0f, 1f);
            Color yellow = new Color(1f, 0.92f, 0.016f, 1f);
            Color red = new Color(1f, 0f, 0f, 1f);

            if(battery > (0.75 * batteryLimit) && battery < (1 * batteryLimit)){
                batteryBarColor.color = green;
            } else if(battery > (0.25f * batteryLimit) && battery < (0.75f * batteryLimit)){
                batteryBarColor.color = yellow;
            } else if(battery > (0.01f * batteryLimit) && battery < (0.25f * batteryLimit)) {
                batteryBarColor.color = red;
            }
        } else {
            gameOverScreen.SetActive(true);
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
        // StartCoroutine(LoadAsynchronously(levelName));
        SceneManager.LoadScene(levelName);
    }

    // IEnumerator LoadAsynchronously(string levelName)
    // {
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
    //     loadingScreen.SetActive(true);

    //     while(!operation.isDone){
    //         float progress = Mathf.Clamp01(operation.progress / .9f);
    //         slider.value = progress;
    //         progressText.text = progress * 100 + "%";
    //         yield return null;
    //     }
    // }

    public void QuitGame()
    {
        Application.Quit();
    }
}
