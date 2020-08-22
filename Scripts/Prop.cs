using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Prop : MonoBehaviour
{
    public Sprite[] sprite;
    public SpriteRenderer rend;
    public float speed = 4;
    private float killFloor = 8;
    private float killCelling = -4;
    public GameObject deadObject;
    private bool isWolf;
    private bool runningAway = false;
    public AudioSource _audio;
    public AudioClip _clip;

    private void Start()
    {
        killFloor = GameController.killFloor;
        killCelling = GameController.killCelling;
        if (sprite.Length > 0)
        {
            int a;
            a = Random.Range(0, sprite.Length);
            rend.sprite = sprite[a];
        }

        //Check if I'm a wolfy
        if (CompareTag("Wolf"))
        {
            isWolf = true;
        }
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
        UpdateDepth();
        if(transform.position.y < killFloor || transform.position.y > killCelling)
        {
            Destroy(gameObject);
        }

        //Check for wolf repellent
        if (isWolf)
        {
            if (StaticContainer.wolfRepellentTime > 0)
            {
                int dist;
                if (StaticContainer.score > 500)
                {
                    dist = 6;
                }
                else
                {
                    dist = 4;
                }
                if (transform.position.y < dist && runningAway == false && transform.position.y > 2)
                {
                    speed = -speed;
                    runningAway = true;
                    _audio.pitch = 0.9f + Random.Range(0f, 0.2f);
                    _audio.PlayOneShot(_clip);
                }
            }
        }
    }

    void UpdateDepth()
    {
            float depth;
            depth = transform.position.y * 0.01f;
            transform.position = new Vector3(transform.position.x, transform.position.y, depth);
    }

    public void Kill()
    {
        Instantiate(deadObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
