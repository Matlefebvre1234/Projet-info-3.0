using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleche : MonoBehaviour
{
    public GameObject fleche;
    public Animator anim;
    private float compteur;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("fleche", true);
    }

    // Update is called once per frame
    void Update()
    {
        compteur += Time.deltaTime;

        if (compteur >= 3)
        {
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("TourFleche"))
            {
                Tirer();
                Debug.Log("Hello");
                
                anim.SetBool("fleche", false);
            }
            
            compteur = 0;
        }
        anim.SetBool("fleche", true);
    }

    void Tirer()
    {
        Instantiate(fleche, transform.position, Quaternion.identity);
    }
}
