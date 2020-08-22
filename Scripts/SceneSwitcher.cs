using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static int sceneTarget;
    public AudioSource bark;

    public void SwitchScene()
    {
        Menu.gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneTarget);
    }

    public void SwitchScenePartTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(2);
        StaticContainer.score = 500;
        StaticContainer.TryAgainVideo -= 1;
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToHighScoreTable()
    {
        SceneManager.LoadScene(0);
    }

    public void Bark()
    {
        bark.Play();
    }
}
