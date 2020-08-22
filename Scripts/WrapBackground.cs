using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapBackground : MonoBehaviour
{

    public float speed;
    private float offset;
    private float pos;
    public Vector2 startPos;

    void Start()
    {
        transform.position = new Vector2(0,startPos.y);
        offset = 0f;
        pos = startPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime;
        pos += Time.deltaTime * speed;
        transform.position = new Vector2(0, pos);
        if (offset > 50)
        {
            pos = startPos.y;
            offset = 0f;
        }
    }
}
