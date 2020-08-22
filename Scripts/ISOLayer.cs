using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISOLayer : MonoBehaviour
{

    private float depth;

    // Update is called once per frame
    void Update()
    {
        depth = transform.position.y * 0.01f;
        transform.position = new Vector3(transform.position.x, transform.position.y, depth);
        Debug.Log("Depth" + depth);
    }
}
