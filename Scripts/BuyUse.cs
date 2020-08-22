using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyUse : MonoBehaviour
{
    public bool isHat;
    public AudioSource _audio;
    public AudioClip _sound;
    public AudioClip _failSound;
    public TextMeshProUGUI _text;

    private bool owned;

    public void Awake()
    {
        Check();
    }

    public void OnEnable()
    {
        _text.text = "Reset";
    }

    public void Check()
    {
        if (PlayerPrefs.GetInt(StaticContainer.selectedItemKey) == 1)
        {
            if (isHat && StaticContainer.hat == StaticContainer.hatSelected)
            {
                _text.text = "Equiped";
            }
            else if (!isHat && StaticContainer.color == StaticContainer.colorSelected)
            {
                _text.text = "Equiped";
            }
            else
            {
                _text.text = "Use";
            }

            owned = true;
        }
        else
        {
            _text.text = "Buy - " + StaticContainer.selectedItemPrice.ToString();
            owned = false;
        }
    }

    public void Assign()
    {
        if (owned)
        {
            if (isHat)
            {
                StaticContainer.hat = StaticContainer.hatSelected;
            }
            else
            {
                StaticContainer.color = StaticContainer.colorSelected;
            }
            ClickSound();
            Check();
        }
        else
        {
            if (PlayerPrefs.GetInt("coins") >= StaticContainer.selectedItemPrice)
            {
                PlayerPrefs.SetInt(StaticContainer.selectedItemKey, 1);
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - StaticContainer.selectedItemPrice);

                if (isHat)
                {
                    StaticContainer.hat = StaticContainer.hatSelected;
                }
                else
                {
                    StaticContainer.color = StaticContainer.colorSelected;
                }
                Check();
                ClickSound();
            }
            else
            {
                //Can't buy
                InsufficientFunds();
            }
        }
    }

    private void InsufficientFunds()
    {
        _audio.PlayOneShot(_failSound);
    }

    private void ClickSound()
    {
        _audio.PlayOneShot(_sound);
    }
}
