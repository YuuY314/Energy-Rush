using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
    public GameObject shopScreen;
    public Text priceLabel;
    public Text descriptionLabel;
    public string itemName;
    public int currentGears;
    public int requiredGears;
    public Text normal;
    public Player player;
    void Start()
    {
        currentGears = GameGlobalLogic.gRustyGears+(3 * GameGlobalLogic.gNormalGears)+(5 * GameGlobalLogic.gStainlessGears);
        normal.text = currentGears.ToString();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Exit()
    {
        shopScreen.SetActive(false);
        priceLabel.text = "";
        descriptionLabel.text = "";
        requiredGears = 0;
        itemName = "";
        Time.timeScale = 1;
        player.enabled = true;
    }

    public void SelectItem(string name)
    {
        if(name == "Battery"){
            priceLabel.text = "10";
            descriptionLabel.text = "Uma bateria para salvar sua vida nos piores momentos.";
            requiredGears = 10;
        }

        if(name == "Weapon"){
            priceLabel.text = "30";
            descriptionLabel.text = "Um aprimoramento para o dano da sua arma.";
            requiredGears = 30;
        }

        itemName = name;
    }

    public void OK()
    {
        if(itemName == "Battery"){
            if(currentGears >= requiredGears){
                GameLogic.instance.batterySFX.Play();
                GameGlobalLogic.gBatteryBackup++;
                currentGears -= requiredGears;
                normal.text = currentGears.ToString();
            }
        }

        if(itemName == "Weapon"){
            if(currentGears >= requiredGears){
                GameLogic.instance.itemSFX.Play();
                GameGlobalLogic.gBulletDamage++;
                currentGears -= requiredGears;
                normal.text = currentGears.ToString();
            }
        }

        Time.timeScale = 1;
        shopScreen.SetActive(false);
        player.enabled = true;
    }
}
