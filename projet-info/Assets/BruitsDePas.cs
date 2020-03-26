﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitsDePas : MonoBehaviour
{
    Rigidbody2D bC;

    // Start is called before the first frame update
    void Start()
    {
        bC = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bC.velocity.x != 0 && GetComponent<AudioSource>().isPlaying == false || bC.velocity.y != 0 && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }

        if (bC.velocity.x == 0 && bC.velocity.y == 0)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
