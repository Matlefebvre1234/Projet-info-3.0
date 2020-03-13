using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : MonoBehaviour
{
    public Animator coffreAnimerPlein;
    public Animator coffreAnimerVide;

    private bool coffreOuvert;
    private bool coffreFermer;

    // Start is called before the first frame update
    void Start()
    {
        coffreOuvert = false;
        coffreFermer = false;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (coffreOuvert == false)
        {
            coffreAnimerPlein.SetBool("coffre", true);
            coffreOuvert = true;
        }

        if (coffreOuvert == true)
        {
            coffreAnimerVide.SetBool("coffre vide", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (coffreFermer == false)
        {
            coffreAnimerPlein.SetBool("coffre", false);
            coffreFermer = true;
        }
        if (coffreFermer == true)
        {
            coffreAnimerVide.SetBool("coffre vide", false);
        }
    }
}
