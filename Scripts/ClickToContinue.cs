using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour
{

    public float waitTime;
    public GameObject switcher;
    public int sceneToGoTo = 0;

    void Update()
    {
        if (waitTime > 0)
            waitTime-=Time.deltaTime;
        if (Input.GetMouseButtonDown(0) == true && waitTime <= 0)
        {
            SceneSwitcher.sceneTarget = sceneToGoTo;
            switcher.SetActive(true);
        }
    }
}
