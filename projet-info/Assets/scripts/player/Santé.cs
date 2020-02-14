using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santé : MonoBehaviour
{
    public int santeeMax = 100;
    public int santee;
    public BarreSantee barreSante;

    // Start is called before the first frame update
    void Start()
    {
        santee = santeeMax;
        barreSante.SetSanteeMax(santee);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            attaque(10);
        }
    }

    public void attaque(int qteAttaque)
    {
        santee = santee - qteAttaque;
        barreSante.SetSantee(santee);
    }
}
