using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score").ToString();
    }
}
