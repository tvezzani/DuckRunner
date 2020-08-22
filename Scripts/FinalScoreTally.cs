using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class FinalScoreTally : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public float delay = 0.001f;
    public GameObject[] ducklings;
    public AudioSource source;
    private string currentText;
    public string text;
    private int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        text = "Total Score\n------------\n";
        StartCoroutine(DisplayDuckFeet());
        finalScore = 1000 + StaticContainer.ducklingsSurvived*50 + StaticContainer.nearPasses*2 + StaticContainer.wolfPasses*5;
        StaticContainer.score = finalScore;
        switch (StaticContainer.ducklingsSurvived)
        {
            case 0:
                Destroy(ducklings[0]);
                Destroy(ducklings[1]);
                Destroy(ducklings[2]);
                break;
            case 1:
                Destroy(ducklings[1]);
                Destroy(ducklings[2]);
                break;
            case 2:
                Destroy(ducklings[2]);
                break;
        }

    }

    private void Update()
    {
        textMesh.text = text + currentText;
    }


    IEnumerator DisplayDuckFeet()
    {
        int counter = -1;
        while (counter < 1000)
        {
            if (1000 - counter > 100)
            {
                counter += 100;
            }
            else
            {
                counter++;
            }

            currentText = counter + " Duck Feet\n";
            PlaySound();
            yield return new WaitForSeconds(delay);
            if (counter == 1000)
            {
                text = text + currentText;
                currentText = "";
                StartCoroutine(DisplaySurvivingDucklings());
            }
        }
    }

    IEnumerator DisplaySurvivingDucklings()
    {
        int counter = -1;
        while (counter < StaticContainer.ducklingsSurvived)
        {
            counter++;
            currentText = "+\n" + counter + " Ducklings X 50\n";
            PlaySound();
            yield return new WaitForSeconds(delay);
            if (counter == StaticContainer.ducklingsSurvived)
            {
                text = text + currentText;
                currentText = "";
               StartCoroutine(DisplayNearPasses());
            }
        }
    }

    IEnumerator DisplayNearPasses()
    {
        int counter = -1;
        while (counter < StaticContainer.nearPasses)
        {
            if (StaticContainer.nearPasses - counter > 10)
            {
                counter += 10;
            }
            else
            {
                counter++;
            }
            currentText = "+\n" + counter + " Near Passes X 2\n";
            PlaySound();
            yield return new WaitForSeconds(delay);
            if (counter == StaticContainer.nearPasses)
            {
                text = text + currentText;
                currentText = "";
                StartCoroutine(DisplayWolfPasses());
            }
        }
    }

    IEnumerator DisplayWolfPasses()
    {
        int counter = -1;
        while (counter < StaticContainer.wolfPasses)
        {
            if (StaticContainer.wolfPasses - counter > 10)
            {
                counter += 10;
            }
            else
            {
                counter++;
            }
            currentText = "+\n" + counter + " Wolf Passes X 5\n";
            PlaySound();
            yield return new WaitForSeconds(delay);
            if (counter == StaticContainer.wolfPasses)
            {
                text = text + currentText;
                currentText = "";
                StartCoroutine(DisplayFinalScore());
            }
        }
    }

    IEnumerator DisplayFinalScore()
    {
        int counter = -1;
        while (counter < finalScore)
        {
            if (finalScore - counter > 100)
            {
                counter += 100;
            }
            else if (finalScore - counter > 10)
            {
                counter += 10;
            }
            else
            {
                counter++;
            }

            currentText = "=\n" + counter + " Points\n";
            PlaySound();
            yield return new WaitForSeconds(delay);
            if (counter == finalScore)
            {
                currentText = "=\n" + counter + " Points\n\nGood Job!";
                text = text + currentText;
                currentText = "";
            }
        }
    }

    void PlaySound()
    {
        source.Play();
    }

}
