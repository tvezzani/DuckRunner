using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TryAgainButton : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Video to try again - " + StaticContainer.TryAgainVideo.ToString() + " left";
    }

    private void OnEnable()
    {
        if (StaticContainer.TryAgainVideo < 1 )
        {
            gameObject.SetActive(false);
        }
    }
}
