using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGlobalLogic : MonoBehaviour
{
    public static float gBattery = 300;
    public static int gBatteryLimit = 300;
    public static int gBatteryBackup = 0;
    public static int gRustyGears;
    public static int gNormalGears;
    public static int gStainlessGears;

    public static bool gIsEquippedWithWeapon1; //sempre true enquanto estiver em desenvolvimento
}
