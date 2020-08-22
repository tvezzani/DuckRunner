using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyWolfRepellent : MonoBehaviour
{
    public TextMeshProUGUI text;
    public AudioSource _audio;
    public AudioClip _sound;
    public AudioClip _insufficientFunds;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "x " + PlayerPrefs.GetInt("wolfRepellent").ToString();
    }

    public void BuyRepellent()
    {
        if (PlayerPrefs.GetInt("coins") >= 3 && PlayerPrefs.GetInt("wolfRepellent") < 99)
        {
            PlayerPrefs.SetInt("wolfRepellent", PlayerPrefs.GetInt("wolfRepellent") + 1);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 3);
            text.text = "x " + PlayerPrefs.GetInt("wolfRepellent").ToString();
            BuySound();
        }
        else
        {
            InsufficientFunds();
        }
    }

    public void BuySound()
    {
        _audio.PlayOneShot(_sound);
    }

    public void InsufficientFunds()
    {
        _audio.PlayOneShot(_insufficientFunds);
    }

}
