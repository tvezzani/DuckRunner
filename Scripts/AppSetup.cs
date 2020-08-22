using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppSetup : MonoBehaviour
{

    private void Awake()
    {
        Application.targetFrameRate = 60;
        StaticContainer.score = 0;
        StaticContainer.coinsEarnedThisRound = 0;
        StaticContainer.nearPasses = 0;
        StaticContainer.wolfPasses = 0;
        StaticContainer.ducklingsSurvived = 3;
    }

}
