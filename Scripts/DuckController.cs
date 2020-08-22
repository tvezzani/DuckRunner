using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour
{

    public float moveSpeed = 1;
    public float xMaxBoundary = 13.85f;
    public float xMinBoundary = 0.15f;
    public float scoreVariable = 7;

    void Update()
    {
        MoveDuck();
        UpdateScore();
    }

    void UpdateScore()
    {
        StaticContainer.score += scoreVariable * Time.deltaTime;
    }

    void MoveDuck()
    {
        float h = moveSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.y < Screen.height*(5/6.5))
            {
                if (Input.touchCount > 1)
                {
                    h = 0;
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    h = moveSpeed * Time.deltaTime;
                }
                else
                {
                    h = -moveSpeed * Time.deltaTime;
                }
            }
        }

        transform.position = new Vector3(this.transform.position.x + h, this.transform.position.y, transform.position.z);


        //Make Boundaries
        if (transform.position.x < xMinBoundary)
        {
            transform.position = new Vector3(xMinBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xMaxBoundary)
        {
            transform.position = new Vector3(xMaxBoundary, transform.position.y, transform.position.z);
        }
    }
}
