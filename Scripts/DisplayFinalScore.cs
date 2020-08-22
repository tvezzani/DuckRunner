using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayFinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public bool coins;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = Mathf.RoundToInt(StaticContainer.score);

        if (coins)
        {
            score = StaticContainer.coinsEarnedThisRound;
        }

        finalScore.text = score.ToString();

    }
}
