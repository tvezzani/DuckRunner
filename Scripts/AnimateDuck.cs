using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDuck : MonoBehaviour
{

    public Transform leftFoot;
    public Transform rightFoot;
    public Transform body;
    public Transform mask;
    public Transform hat;
    public SpriteRenderer backgroundSprite;
    public Transform footprints;

    public float walkSpeed = 2f;
    public float stride = 0.05f;
    public float setFootDist = 0.14f;
    public float setLegSpacing = -0.25f;

    private float anim;
    private bool toggle = true;
    private float hatStartHeight;
    public Sprite[] sprites;
    public Sprite[] maskSprites;
    public float depth;

    public bool makeSound;
    public float quackFrequency;

    public AudioClip[] footsteps;
    public AudioClip quackSound;
    public AudioSource source;

    private int lastSound = 0;

    private void Start()
    {
        if (hat != null)
            hatStartHeight = hat.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateFeet();
        UpdateDepth();
        CheckFootPrints();
    }

    void UpdateDepth()
    {
        depth = transform.position.y * 0.01f;
        transform.position = new Vector3(transform.position.x, transform.position.y, depth);
    }

    void CheckFootPrints()
    {
        if (backgroundSprite != null || footprints != null)
        {
            if (backgroundSprite.sprite.name == "Snow")
            {
                footprints.gameObject.SetActive(true);
            }
            else
            {
                footprints.gameObject.SetActive(false);
            }
        }
    }

    void PlayFootStep()
    {
        source.volume = 0.3f;
        int sound = 0;

        do
        {
            sound = Random.Range(0, footsteps.Length);

        } while (sound == lastSound);

        source.PlayOneShot(footsteps[sound]);
        lastSound = sound;
    }

    void AnimateFeet()
    {
        if (toggle)
        {
            if (anim < stride)
            {
                anim += Time.deltaTime * walkSpeed;
            }
            else
            {
                toggle = false;
                if (makeSound)
                    PlayFootStep();
            }
        }
        else
        {
            if (anim > -stride)
            {
                anim -= Time.deltaTime * walkSpeed;
            }
            else
            {
                toggle = true;
                if (makeSound)
                    PlayFootStep();
            }
        }


        leftFoot.transform.position = new Vector3(transform.position.x + setLegSpacing, transform.position.y + anim + setFootDist, transform.position.z);
        rightFoot.transform.position = new Vector3(transform.position.x - setLegSpacing, transform.position.y + - anim + setFootDist, transform.position.z);
        body.transform.position = new Vector3(transform.position.x,transform.position.y + (Mathf.Abs(anim)/1.5f),transform.position.z-0.001f);
        if (hat != null)
            hat.transform.position = new Vector3(transform.position.x, transform.position.y + hatStartHeight + (Mathf.Abs(anim) / 1.5f), transform.position.z - 0.003f);
        if (mask != null)
            mask.transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Abs(anim) / 1.5f), transform.position.z - 0.002f);

        //Animate waddle
        SpriteRenderer rend;
        Sprite spr;
        rend = body.GetComponent<SpriteRenderer>();
        if (anim > stride / 3)
        {
            spr = sprites[1];
            if (hat!= null)
                hat.position = new Vector3(transform.position.x + 0.03f, hat.transform.position.y, hat.transform.position.z);
        }
        else if (anim < -stride / 3)
        {
            spr = sprites[2];
            if (hat != null)
                hat.position = new Vector3(transform.position.x - 0.03f, hat.transform.position.y, hat.transform.position.z);
        }
        else
        {
            spr = sprites[0];
            if (hat != null)
                hat.position = new Vector3(transform.position.x, hat.transform.position.y, hat.transform.position.z);
        }
        rend.sprite = spr;
        rend.color = StaticContainer.color;
        if (hat != null)
        {
            rend = hat.GetComponent<SpriteRenderer>();
            rend.sprite = StaticContainer.hat;
        }

        //Mask Waddle
        if (maskSprites != null && mask != null)
        {
            rend = mask.GetComponent<SpriteRenderer>();
            if (anim > stride / 3)
            {
                spr = maskSprites[1];
            }
            else if (anim < -stride / 3)
            {
                spr = maskSprites[2];
            }
            else
            {
                spr = maskSprites[0];
            }
            rend.sprite = spr;
        }
    }
}
