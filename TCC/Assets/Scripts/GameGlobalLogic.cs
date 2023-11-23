using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGlobalLogic : MonoBehaviour
{
    public static float gBattery = 300;
    public static int gBatteryLimit = 300;
    public static int gBatteryBackup;
    public static int gRustyGears;
    public static int gNormalGears;
    public static int gStainlessGears;
    public static int gBulletDamage = 1;

    public static bool gIsEquippedWithWeapon1; //sempre true enquanto estiver em desenvolvimento
    public static bool gIsEquippedWithDoubleJump;
}
