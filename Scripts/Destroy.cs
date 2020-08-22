using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public float destroyTimer;
    private float counter;
    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > destroyTimer)
            Destroy(this.gameObject);
    }
}
