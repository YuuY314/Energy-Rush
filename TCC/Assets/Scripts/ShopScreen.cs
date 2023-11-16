using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
    public GameObject shopScreen;

    public void Exit()
    {
        shopScreen.SetActive(false);
    }
}
