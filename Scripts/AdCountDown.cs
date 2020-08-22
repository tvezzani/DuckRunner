using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdCountDown : MonoBehaviour
{
#if UNITY_IOS
    private string gameId = "3681364";
#elif UNITY_ANDROID
    private string gameId = "3681365";
#endif

    // Start is called before the first frame update
    void Start()
    {

            // Initialize the Ads service:
            Advertisement.Initialize(gameId, StaticContainer.advertismentTestMode);

            if (StaticContainer.adCounter > 4)
            {
                StaticContainer.adCounter = 0;
                // Show an ad:
                Advertisement.Show();
            }
            else
            {
                StaticContainer.adCounter++;
            }
    }

}
