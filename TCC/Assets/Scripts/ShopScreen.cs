using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
    public Text rustyGearCounter;
    public Text normalGearCounter;
    public Text stainlessGearCounter;

    void Start()
    {
        rustyGearCounter.text = GameGlobalLogic.gRustyGears.ToString();
        normalGearCounter.text = GameGlobalLogic.gNormalGears.ToString();
        stainlessGearCounter.text = GameGlobalLogic.gStainlessGears.ToString();
    }
}
