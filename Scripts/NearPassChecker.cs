using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearPassChecker : MonoBehaviour
{
    public GameObject nearPassGraphic;
    public GameObject wolfPassGraphic; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag == "Prop")
        {
            GameObject graphic = Instantiate(nearPassGraphic);
            graphic.transform.position = transform.position;
            StaticContainer.nearPasses += 1;
        }

        if (collision.tag == "Wolf")
        {
            GameObject graphic = Instantiate(wolfPassGraphic);
            graphic.transform.position = transform.position;
            StaticContainer.wolfPasses += 1;
        }
    }
}
