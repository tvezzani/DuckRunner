using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorPicker : MonoBehaviour
{
    public Color[] colors;
    public SpriteRenderer rend;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = colors[Random.Range(0,colors.Length)];
        StaticContainer.color = color;
        rend.color = color;
    }

}
