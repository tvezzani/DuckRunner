using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttribute : MonoBehaviour
{
    public Color color;
    public Sprite hat;
    public bool isHat;
    public AudioSource _audio;
    public AudioClip _sound;
    public string itemKey;
    public int itemPrice;

    public void Set()
    {
        StaticContainer.selectedItemKey = itemKey;
        StaticContainer.selectedItemPrice = itemPrice;

        if (isHat)
        {
            if (hat != null)
            {
                StaticContainer.hatSelected = hat;
            }
            else
            {
                StaticContainer.hatSelected = null;
            }
        }
        else
        {
            StaticContainer.colorSelected = color;
        }
        ClickSound();
    }

    private void ClickSound()
    {
        _audio.PlayOneShot(_sound);
    }
}