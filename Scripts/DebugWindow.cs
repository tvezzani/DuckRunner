using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class DebugWindow : MonoBehaviour
{

    private TextMeshProUGUI textMesh;
    public GameController controller;

    float deltaTime;
    private string finalText;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        float fps = 1.0f / deltaTime;
        fps = Mathf.Round(fps);
        finalText = "FPS = " + fps;
        finalText += "\n----  ----  ----  ----";

        if (controller != null)
        {
            finalText += "\nwolf timer = " + Mathf.Round(10 * controller.GetWolfFrequencyCountdown())/10;
            finalText += "\nspawn timer = " + Mathf.Round(10 * controller.GetTickCountDown())/10;
            finalText += "\nspawns /sec = " + Mathf.Round(100 * controller.GetFrequency()) / 100;
            finalText += "\n----  ----  ----  ----";
            finalText += "\ndifficulty = " + Mathf.Round(100 * controller.GetDifficulty()) / 100;
            finalText += "\nspawn factor = " + Mathf.Round(100 * controller.GetSpawnFactor()) / 100;
            finalText += "\nwolf chance 1/" + Mathf.Round(100 * controller.GetWolfChance()) / 100;
        }
        else
        {
            finalText += "\nno game ctrl found";
        }


        textMesh.text = finalText;
    }
}
