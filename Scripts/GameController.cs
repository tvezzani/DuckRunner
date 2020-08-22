using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ground;
    public GameObject lava;
    public GameObject shadow;
    public GameObject loseScreen;
    public GameObject player;
    public GameObject[] plainsSpawn;
    public GameObject[] desertSpawn;
    public GameObject[] snowSpawn;
    public GameObject[] lavaSpawn;
    public ParticleSystem rainEffect;
    public ParticleSystem snowEffect;
    public ParticleSystem emberEffect;
    public Sprite[] backgroundSprites;
    public GameObject wolf;
    public GameObject iceWolf;
    public GameObject fireWolf;
    public GameObject warning;
    public GameObject transitionSwitcher;
    public AudioSource backgroundSoundSource;
    public AudioClip rainSound;
    public AudioClip lavaSound;
    public AudioClip windSound;

    private GameObject currentWolf;

    public float startHeight = 7;
    public float wolfStartHeight = 14;

    //Spawns per second
    public float startFrequency = 1;
    public float endFrequency = 60;
    private float frequency;
    private float spawnFactor;

    public float wolfStartChance = 10;
    public float wolfEndChance = 5;
    private float wolfChance;

    public float speed = -4;
    public float wolfSpeed = -8;

    public static bool lose;
    public bool cheatsEnabled;
    public static float killCelling = 15;
    public static float killFloor = -15;

    private bool tick;
    private float counter;
    private bool canSpawnWolf;
    private float wolfFrequencyCountdown = 3;
    private float difficulty;
    private readonly float difficultyInc = 0.014f;

    private Vector2 startGroundPosition;

    void Start()
    {
        Score.scoreValue = 0;
        ResetEffects();
        currentWolf = wolf;
        startGroundPosition = ground.transform.position;
    }

    void Update()
    {
        TrySpawn(GetSpawnType(), speed);
        TrySpawnWolf();
        TrySwitchScene();
        MoveBackground();
        UpdateScore();
        Cheats();

        if (lose)
            LoseGame();

        if (difficulty < 1)
            difficulty += difficultyInc * Time.deltaTime;

        if (difficulty > 1)
            difficulty = 1;

        frequency = startFrequency + ((endFrequency - startFrequency) * difficulty);

        spawnFactor = (60 / frequency);

        wolfChance = wolfStartChance + ((wolfEndChance - wolfStartChance) * difficulty);

        counter += Time.deltaTime;

        if (counter > spawnFactor * Time.deltaTime)
        {
            tick = true;
            counter = 0;
        }
    }

    void UpdateScore()
    {
        Score.scoreValue = StaticContainer.score;
    }

    void TrySwitchScene()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        if (StaticContainer.score >= 500 && scene.buildIndex == 1)
        {
            StaticContainer.score = 500;
            transitionSwitcher.SetActive(true);
            SceneSwitcher.sceneTarget = 2;
        }
        else if (StaticContainer.score >= 1000)
        {
            StaticContainer.score = 1000;
            transitionSwitcher.SetActive(true);
            SceneSwitcher.sceneTarget = 4;
        }
    }

    void TrySpawn(GameObject spawn, float _speed)
    {
        if (tick)
        {
            GameObject newProp;
            newProp = Instantiate(spawn);
            newProp.transform.parent = null;
            newProp.transform.position = new Vector2(Random.Range(0f, 14f), startHeight);
            Prop prop;
            prop = newProp.GetComponent<Prop>();
            prop.speed = _speed;
            tick = false;
        }
    }

    void TrySpawnWolf()
    {
        wolfFrequencyCountdown -= Time.deltaTime;
        if (wolfFrequencyCountdown <= 0)
        {
            wolfFrequencyCountdown = 0.25f;
            if (Random.Range(0, wolfChance) > wolfChance - 1)
            {
                if (player != null)
                {
                    GameObject newProp;
                    newProp = Instantiate(currentWolf);
                    newProp.transform.position = new Vector2(player.transform.position.x, wolfStartHeight);
                    Prop prop;
                    prop = newProp.GetComponent<Prop>();
                    prop.speed = wolfSpeed;

                    GameObject warn;
                    warn = Instantiate(warning);
                    warn.transform.parent = null;
                    warn.transform.position = new Vector2(newProp.transform.position.x, 6.4f);
                }
            }
        }
    }

    GameObject GetSpawnType()
    {
        if (Score.scoreValue < 100 || Score.scoreValue > 900)
        {
            ChangeBackground(backgroundSprites[0]);
            ResetEffects();
            currentWolf = wolf;
            return plainsSpawn[Random.Range(0, plainsSpawn.Length)];
        }
        else if (Score.scoreValue < 200 || Score.scoreValue > 800)
        {
            ChangeBackground(backgroundSprites[0]);
            shadow.SetActive(true);
            Activate(rainEffect);
            ActivateSound(backgroundSoundSource, rainSound);
            currentWolf = wolf;
            return plainsSpawn[Random.Range(0, plainsSpawn.Length)];
        }
        else if (Score.scoreValue < 300 || Score.scoreValue > 700)
        {
            ChangeBackground(backgroundSprites[1]);
            currentWolf = wolf;
            return desertSpawn[Random.Range(0, desertSpawn.Length)];
        }
        else if (Score.scoreValue < 400 || Score.scoreValue > 600)
        {
            ChangeBackground(backgroundSprites[2]);
            Activate(snowEffect);
            ActivateSound(backgroundSoundSource, windSound);
            currentWolf = iceWolf;
            return snowSpawn[Random.Range(0, snowSpawn.Length)];
        }
        else
        {
            ChangeBackground(backgroundSprites[3]);
            lava.SetActive(true);
            Activate(emberEffect);
            ActivateSound(backgroundSoundSource, lavaSound);
            currentWolf = fireWolf;
            return lavaSpawn[Random.Range(0, lavaSpawn.Length)];
        }
    }

    void MoveBackground()
    {
        ground.transform.position = new Vector2(0, ground.transform.position.y + speed * Time.deltaTime);
    }

    void ChangeBackground(Sprite currentBackground)
    {
        //Change sprite background
        if (ground.GetComponent<SpriteRenderer>().sprite != currentBackground)
        {
            ground.GetComponent<SpriteRenderer>().sprite = currentBackground;
            ground.transform.position = startGroundPosition;
            ResetEffects();
        }
    }

    void ResetEffects()
    {
        rainEffect.Stop();
        snowEffect.Stop();
        emberEffect.Stop();
        lava.SetActive(false);
        shadow.SetActive(false);
    }

    //Activate appropriate particle system
    void Activate(ParticleSystem part)
    {
        if (part.isPlaying != true)
        {
            part.Play();
        }
    }

    void ActivateSound(AudioSource source, AudioClip clip)
    {
        if (source.isPlaying == false && loseScreen.activeSelf == false)
        {
            source.PlayOneShot(clip);
        }
    }

    void LoseGame()
    {
        ResetEffects();
        loseScreen.SetActive(true);
        lose = false;
    }

    public float GetWolfFrequencyCountdown()
    {
        return wolfFrequencyCountdown;
    }

    public float GetTickCountDown()
    {
        return counter;
    }

    public bool GetTick()
    {
        return tick;
    }

    public float GetFrequency()
    {
        return frequency;
    }

    public float GetDifficulty()
    {
        return difficulty;
    }

    public float GetSpawnFactor()
    {
        return spawnFactor;
    }

    public float GetWolfChance()
    {
        return wolfChance;
    }

    //Debuging Cheats

    void Cheats()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.W) && cheatsEnabled)
        {
            if (scene.buildIndex == 1)
            {
                StaticContainer.score = 500;
                transitionSwitcher.SetActive(true);
                SceneSwitcher.sceneTarget = 2;
            }
            else
            {
                StaticContainer.score = 1000;
                transitionSwitcher.SetActive(true);
                SceneSwitcher.sceneTarget = 4;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && cheatsEnabled)
        {
            if (scene.buildIndex == 1)
                StaticContainer.score = 0;
            if (scene.buildIndex == 3)
                StaticContainer.score = 500;
            SceneManager.LoadScene(scene.buildIndex);
        }
    }

}
