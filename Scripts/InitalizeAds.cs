using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class InitalizeAds : MonoBehaviour
{
#if UNITY_IOS
    private string gameId = "3681364";
#elif UNITY_ANDROID
    private string gameId = "3681365";
#endif

    void Start()
    {
        Advertisement.Initialize(gameId, StaticContainer.advertismentTestMode);
    }
}
