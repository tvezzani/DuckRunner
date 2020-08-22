using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignAttribute : MonoBehaviour
{
    public SpriteRenderer rend;
    public SpriteRenderer hat;
    public ParticleSystem part;

    // Start is called before the first frame update
    void Start()
    {
        if (rend != null)
        {
            rend.color = StaticContainer.color;
        }

        if (hat != null)
        {
            hat.sprite = StaticContainer.hat;
        }

        if (part != null)
        {
            var main = part.main;
            main.startColor = StaticContainer.color;
        }
    }

}
