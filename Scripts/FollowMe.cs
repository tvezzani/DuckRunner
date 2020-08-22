using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{

    private List<Vector3> storedPositions;
    public GameObject followingMe;
    public GameObject followingMeBackup;
    public GameObject followingMeBackupTwo;
    private readonly int followDistance = 8;

    private void Start()
    {
        storedPositions = new List<Vector3>();
    }

    void Update()
    {
        if (Time.timeScale > 0) // Make sure game is not paused
        {
            if (followingMe != null)
            {
                storedPositions.Add(transform.position);
                if (storedPositions.Count > followDistance)
                {
                    followingMe.transform.position = new Vector3(storedPositions[0].x, followingMe.transform.position.y, followingMe.transform.position.z); //move the player
                    storedPositions.RemoveAt(0); //delete the position that player just move to
                }
            }
            else if (followingMeBackup != null)
            {
                storedPositions.Add(transform.position);
                if (storedPositions.Count > followDistance)
                {
                    followingMeBackup.transform.position = new Vector3(storedPositions[0].x, followingMeBackup.transform.position.y, followingMeBackup.transform.position.z); //move the player
                    storedPositions.RemoveAt(0); //delete the position that player just move to
                }
            }
            else if (followingMeBackupTwo != null)
            {
                storedPositions.Add(transform.position);
                if (storedPositions.Count > followDistance)
                {
                    followingMeBackupTwo.transform.position = new Vector3(storedPositions[0].x, followingMeBackupTwo.transform.position.y, followingMeBackupTwo.transform.position.z); //move the player
                    storedPositions.RemoveAt(0); //delete the position that player just move to
                }
            }
        }
    }
}
