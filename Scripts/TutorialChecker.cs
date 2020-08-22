using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialChecker : MonoBehaviour
{
    private void Start()
    {
        if (StaticContainer.tutorialDone)
            this.gameObject.SetActive(false);
    }

    public void ClearTutorial()
    {
        StaticContainer.tutorialDone = true;
    }
}
