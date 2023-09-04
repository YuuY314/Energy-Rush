using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [Header("Energy")]
    public static GameLogic instance;
    public float battery;
    public int batteryLimit = 300;
    private int newBattery;
    public Slider batteryBar;
    public Image batteryBarColor;

    [Header("Gears")]
    public int rustyGears;
    public int normalGears;
    public int stainlessGears;

    // public GameObject loadingScreen;
    // public Slider slider;
    // public Text progressText;

    [Header("Game Over")]
    public GameObject gameOverScreen;
    public bool isGameOver;
    
    [Header("SFX")]
    public AudioSource gearSFX;
    public AudioSource batterySFX;
    public AudioSource itemSFX;
    public AudioSource gameOverSFX;
    public AudioSource wallDestructionSFX;

    [Header("Voices")]
    public AudioSource vendingMachineVoice1;
    public AudioSource vendingMachineVoice2;

    void Start()
    {
        instance = this;
        battery = GameGlobalLogic.gBattery;
        batteryLimit = GameGlobalLogic.gBatteryLimit;
        rustyGears = GameGlobalLogic.gRustyGears;
        normalGears = GameGlobalLogic.gNormalGears;
        stainlessGears = GameGlobalLogic.gStainlessGears;
        UpdateBattery();
    }

    void Update()
    {
        // UpdateBattery();
    }

    public void UpdateBattery()
    {
        if(battery > 0){
            battery -= Time.deltaTime;
            newBattery = (int) battery;
            UpdateBatteryBar();


            Color normal = new Color(0f, 0.9921569f, 1f, 1f);
            Color warn = new Color(0.7333333f, 0.9294118f, 0f, 1f);
            Color danger = new Color(0.8352941f, 0f, 0f, 1f);

            if(battery > (0.75 * batteryLimit) && battery < (1 * batteryLimit)){
                batteryBarColor.color = normal;
            } else if(battery > (0.25f * batteryLimit) && battery < (0.75f * batteryLimit)){
                batteryBarColor.color = warn;
            } else if(battery > (0.01f * batteryLimit) && battery < (0.25f * batteryLimit)) {
                batteryBarColor.color = danger;
            }
        } else {
            gameOverScreen.SetActive(true);
            // isGameOver = true;
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
        GameGlobalLogic.gBattery = battery;
        GameGlobalLogic.gBatteryLimit = batteryLimit;
        GameGlobalLogic.gRustyGears = rustyGears;
        GameGlobalLogic.gNormalGears = normalGears;
        GameGlobalLogic.gStainlessGears = stainlessGears;
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
