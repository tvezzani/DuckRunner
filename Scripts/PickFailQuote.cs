using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickFailQuote : MonoBehaviour
{

    private TextMeshProUGUI textPro;
    public string[] quotes;
    private readonly string defaultQuote = "It seems your duck has died. How unfortunate :(";

    // Start is called before the first frame update
    void Start()
    {
        textPro = GetComponent<TextMeshProUGUI>();

        if (quotes.Length > 0)
        {
            textPro.text = quotes[Random.Range(0, quotes.Length)];
        }
        else
        {
            textPro.text = defaultQuote;
        }
    }

}
