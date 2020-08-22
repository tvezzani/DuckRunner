using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoin : MonoBehaviour
{
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + amount);
        StaticContainer.coinsEarnedThisRound += amount;
    }
}
