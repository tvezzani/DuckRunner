using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Killable : MonoBehaviour
{
    public GameObject deadObject;
    public bool isMainPlayer;
    public Killable[] extraLives;
    public Killable _parent;
    public bool killed;
    private int lives;

    private void Start()
    {
        lives = extraLives.Length;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Coin")
        {
            col.BroadcastMessage("Kill");
        }
        else if (lives > 0 && col.tag != "Wolf")
        {
            if (extraLives[lives - 1] != null)
            {
                extraLives[lives - 1].killed = true;
            }
            else if (extraLives[lives - 2] != null)
            {
                extraLives[lives - 2].killed = true;
            }
            else if (extraLives[lives - 3] != null)
            {
                extraLives[lives - 3].killed = true;
            }
            lives -= 1;
            col.BroadcastMessage("Kill");
        }
        else
        {
            GameObject d = Instantiate(deadObject);
            d.transform.position = transform.position;
            if (isMainPlayer)
            {
                GameController.lose = true;

            }
            else
            {
                StaticContainer.ducklingsSurvived -= 1;

            }
            if (_parent != null)
            {
                _parent.lives -= 1;
            }
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (killed && deadObject != null)
        {
            Instantiate(deadObject, transform.position, transform.rotation);
            StaticContainer.ducklingsSurvived -= 1;
            Destroy(gameObject);
        }
        else
        {
            killed = false;
        }
    }
}
