using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckItemLocked : MonoBehaviour
{
    public string itemID;
    public Image graphic;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(itemID) == 1)
        {
            graphic.enabled = false;
        }
        else
        {
            graphic.enabled = true;
        }
    }
}
