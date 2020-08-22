using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticContainer : MonoBehaviour
{
    //Just a placeholder for static public values
    public static float score;
    public static int adCounter = 3;
    public static int nearPasses;
    public static int wolfPasses;
    public static int ducklingsSurvived = 3;
    public static int coinsEarnedThisRound;
    public static int TryAgainVideo = 3;
    public static bool showFPSCounter;
    public static bool musicIsOn;
    public static bool soundIsOn;
    public static bool tutorialDone = false;
    public static bool advertismentTestMode = false;
    public static Color color = Color.white;
    public static Color colorSelected = Color.white;
    public static Sprite hat;
    public static Sprite hatSelected;
    public static string selectedItemKey = "";
    public static int selectedItemPrice = 0;
    public static float wolfRepellentTime = 0;
}
