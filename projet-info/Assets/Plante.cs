using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plante : MonoBehaviour
{
    public float TempReload =3f;
    public GameObject projectile;
    private float temp = 0f;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Niveau Difficulté") == 1)
        {
            TempReload = 3f;
            transform.gameObject.GetComponent<Santé>().santeeMax = 100;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
        {
            TempReload = 2.75f;
            transform.gameObject.GetComponent<Santé>().santeeMax = 125;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
        {
            TempReload = 2.5f;
            transform.gameObject.GetComponent<Santé>().santeeMax = 150;
        }
    }

    // Update is called once per frame
    void Update()
    {
        temp += 1 * Time.deltaTime;

        if (temp >= TempReload)
        {
            Tirer();
            temp = 0;
        }
    }

    private void Tirer()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
