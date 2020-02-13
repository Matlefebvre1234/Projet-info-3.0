using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionJoueur
{
    private Transform transforme;
    private Vector3 position = new Vector3();

    // Update is called once per frame
    void Update()
    {
        position.x = transforme.position.x;
        position.y = transforme.position.y;
    }
    
    public Vector3 EnvoyerPos()
    {
        return position;
    }
}
