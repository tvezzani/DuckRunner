using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    public bool cheatsEnabled;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && cheatsEnabled)
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown(KeyCode.R) && cheatsEnabled)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
    }
}
