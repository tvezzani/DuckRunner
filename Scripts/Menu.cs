using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.Advertisements;

public class Menu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseUI;
    public GameObject settingUI;
    public GameObject shopMenuUI;
    public GameObject skinUI;
    public GameObject hatsUI;
    public GameObject powerUpsUI;
    public GameObject gameUI;
    public GameObject switcher;
    public GameObject debugWindow;

    public Toggle debugToggle;
    public Toggle musicToggle;
    public Toggle soundToggle;

    public TMP_InputField nameInput;

    public AudioSource _audio;
    public AudioClip click;
    public AudioMixer mixer;
    public GameObject leftUI;
    public GameObject rightUI;

    //For toggle switches to not trigger full even when called in script.
    private bool triggerSleep = false;

    private void Awake()
    {
        //DO NOT --EVER-- RELEASE WITH DELETE ALL
        //PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("hat6")) //Ver 1.0.1
        {
            PlayerPrefs.SetInt("showDebugWindow", 0);
            PlayerPrefs.SetInt("musicIsOn", 1);
            PlayerPrefs.SetInt("soundIsOn", 1);
            PlayerPrefs.SetInt("coins", 0);
            PlayerPrefs.SetString("name", "untitled");

            for (int i = 1; i < 11; i++)
            {
                PlayerPrefs.SetInt("highscore" + i, 0);
                PlayerPrefs.SetString("highscoreName" + i, "---");
            }

            PlayerPrefs.SetInt("skin0", 1);
            PlayerPrefs.SetInt("hat0", 1);

            for (int i = 1; i < 11; i++)
            {
                PlayerPrefs.SetInt("skin" + i, 0);
            }

            for (int i = 1; i < 7; i++)
            {
                PlayerPrefs.SetInt("hat" + i, 0);
            }
        }

        if (!PlayerPrefs.HasKey("hat7")) //Ver 1.1.0
        {
            PlayerPrefs.SetInt("hat7", 0);
            PlayerPrefs.SetInt("hat8", 0);
            PlayerPrefs.SetInt("hat9", 0);
            PlayerPrefs.SetInt("wolfRepellent", 0);
        }

    }

    public void Start()
    {
        if (debugWindow != null)
        {
            if (ToBool(PlayerPrefs.GetInt("showDebugWindow")) == true)
            {
                debugWindow.SetActive(true);
            }
            else
            {
                debugWindow.SetActive(false);
            }
        }

        if (ToBool(PlayerPrefs.GetInt("musicIsOn")) == true)
        {
            mixer.SetFloat("musicVolume", 0);
        }
        else
        {
            mixer.SetFloat("musicVolume", -80);
        }

        if (ToBool(PlayerPrefs.GetInt("soundIsOn")) == true)
        {
            mixer.SetFloat("soundVolume", 0);
        }
        else
        {
            mixer.SetFloat("soundVolume", -80);
        }

        if (PlayerPrefs.GetString("name") != "untitled" && nameInput != null)
        {
            nameInput.text = PlayerPrefs.GetString("name");
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        ClickSound();
    }

    public void Home()
    {
        SceneSwitcher.sceneTarget = 0;
        switcher.SetActive(true);
        Time.timeScale = 1f;
        ClickSound();
    }

    public void Shop()
    {
        SceneSwitcher.sceneTarget = 5;
        switcher.SetActive(true);
        ClickSound();
    }

    public void Back()
    {
        pauseUI.SetActive(true);
        settingUI.SetActive(false);
        ClickSound();
    }

    public bool ToBool(int val)
    {
        if (val == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Settings()
    {
        settingUI.SetActive(true);
        pauseUI.SetActive(false);
        ClickSound();
        if (debugToggle != null)
        {
            if (debugToggle.isOn != ToBool(PlayerPrefs.GetInt("showDebugWindow")))
            {
                triggerSleep = true;
                debugToggle.isOn = ToBool(PlayerPrefs.GetInt("showDebugWindow"));
            }

        }

        if (musicToggle.isOn != ToBool(PlayerPrefs.GetInt("musicIsOn")))
        {
            triggerSleep = true;
            musicToggle.isOn = ToBool(PlayerPrefs.GetInt("musicIsOn"));
        }

        if (soundToggle.isOn != ToBool(PlayerPrefs.GetInt("soundIsOn")))
        {
            triggerSleep = true;
            soundToggle.isOn = ToBool(PlayerPrefs.GetInt("soundIsOn"));
        }
    }

    public void StartGame()
    {
        SceneSwitcher.sceneTarget = 1;
        switcher.SetActive(true);
        ClickSound();
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        ClickSound();
    }

    public void Skins()
    {
        skinUI.SetActive(true);
        shopMenuUI.SetActive(false);
        ClickSound();
    }

    public void Hats()
    {
        hatsUI.SetActive(true);
        shopMenuUI.SetActive(false);
        ClickSound();
    }

    public void PowerUps()
    {
        powerUpsUI.SetActive(true);
        shopMenuUI.SetActive(false);
        ClickSound();
    }

    public void MoreCoins()
    {
        ClickSound();
    }

    public void BackShopMenu()
    {
        skinUI.SetActive(false);
        hatsUI.SetActive(false);
        powerUpsUI.SetActive(false);
        shopMenuUI.SetActive(true);
        StaticContainer.selectedItemKey = "";
        StaticContainer.selectedItemPrice = 0;
        StaticContainer.hatSelected = null;
        StaticContainer.colorSelected = Color.white;
        ClickSound();
    }

    public void TutorialLeft()
    {
        leftUI.SetActive(false);
    }

    public void TutorialRight()
    {
        rightUI.SetActive(false);
    }

    private void ClickSound()
    {
        _audio.PlayOneShot(click);
    }

    public void ToggleFpsChecker()
    {
        if (triggerSleep == false)
        {
            ClickSound();
            if (ToBool(PlayerPrefs.GetInt("showDebugWindow")) == true)
            {
                debugWindow.SetActive(false);
                PlayerPrefs.SetInt("showDebugWindow", 0);
            }
            else
            {
                debugWindow.SetActive(true);
                PlayerPrefs.SetInt("showDebugWindow", 1);
            }
        }
        else
        {
            triggerSleep = false;
        }

    }

    public void ToggleMusic()
    {
        if (triggerSleep == false)
        {
            ClickSound();
            if (ToBool(PlayerPrefs.GetInt("musicIsOn")) == true)
            {
                mixer.SetFloat("musicVolume", -80);
                //set int to 0 for false
                PlayerPrefs.SetInt("musicIsOn", 0);
            }
            else
            {
                mixer.SetFloat("musicVolume", 0);
                //set int to 1 for 'true'
                PlayerPrefs.SetInt("musicIsOn", 1);
            }
        }
        else
        {
            triggerSleep = false;
        }
    }

    public void ToggleSound()
    {
        if (triggerSleep == false)
        {
            ClickSound();
            if (ToBool(PlayerPrefs.GetInt("soundIsOn")) == true)
            {
                mixer.SetFloat("soundVolume", -80);
                //set int to 0 for false
                PlayerPrefs.SetInt("soundIsOn", 0);
            }
            else
            {
                mixer.SetFloat("soundVolume", 0);
                //set int to 1 for 'true'
                PlayerPrefs.SetInt("soundIsOn", 1);
            }
        }
        else
        {
            triggerSleep = false;
        }
    }

    public void ChangeName()
    {
        if (nameInput.text == "")
        {
            PlayerPrefs.SetString("name", "untitled");
        }
        else
        {
            PlayerPrefs.SetString("name", nameInput.text);
        }
    }
}
