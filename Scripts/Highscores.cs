using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscores : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nameText;
    private int score;
    private string playerName;
    private int buffer;
    private string bufferName;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "";
        nameText.text = "";

        playerName = PlayerPrefs.GetString("name");

        score = Mathf.RoundToInt(StaticContainer.score);
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetInt("highscore" + i) < score)
            {
                buffer = PlayerPrefs.GetInt("highscore" + i);
                bufferName = PlayerPrefs.GetString("highscoreName" + i);
                PlayerPrefs.SetInt("highscore" + i, score);
                PlayerPrefs.SetString("highscoreName" + i, playerName);
                score = buffer;
                playerName = bufferName;

            }
            scoreText.text += PlayerPrefs.GetInt("highscore" + i) + "\n";
            nameText.text += PlayerPrefs.GetString("highscoreName" + i) + "\n";
        }

        StaticContainer.TryAgainVideo = 3;
    }
}
