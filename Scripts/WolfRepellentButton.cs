using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WolfRepellentButton : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI text;
    public ParticleSystem stinkCould;
    public AudioSource _audio;
    public AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("wolfRepellent") < 1){
            StaticContainer.wolfRepellentTime = 0f;
            gameObject.SetActive(false);
        }

        text.text = "x " + PlayerPrefs.GetInt("wolfRepellent").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticContainer.wolfRepellentTime > 0)
        {
            text.text = " " + (Mathf.Round(StaticContainer.wolfRepellentTime * 10)/10).ToString() + "s";
            if (StaticContainer.wolfRepellentTime < 3)
            {
                text.color = Color.red;
            }

            if (stinkCould != null)
            {
                if (!stinkCould.isPlaying)
                {
                    stinkCould.Play();
                }
            }

            button.interactable = false;
            StaticContainer.wolfRepellentTime -= Time.deltaTime;

            if (StaticContainer.wolfRepellentTime <= 0)
            {
                text.text = "x " + PlayerPrefs.GetInt("wolfRepellent").ToString();
                text.color = Color.white;
                button.interactable = true;
                if (stinkCould != null)
                {
                    stinkCould.Stop();
                }

                if (PlayerPrefs.GetInt("wolfRepellent") <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void ActivateWolfRepellent()
    {
        StaticContainer.wolfRepellentTime = 15;
        PlayerPrefs.SetInt("wolfRepellent", PlayerPrefs.GetInt("wolfRepellent") - 1);
        _audio.PlayOneShot(_clip);
    }
}
