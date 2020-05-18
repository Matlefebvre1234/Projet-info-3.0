using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour
{
    public Animator animator;
    public GameObject fleche;
    public int vitesse = 2;
    private float time = 1;
    public bool rotationDroite = false;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isFire", false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2)
        {
            animator.SetBool("isFire", true);
            animator.SetTrigger("Fire");

            if (transform.rotation.eulerAngles.z.Equals(90))
            {
                Instantiate(fleche, transform.position, Quaternion.Euler(0f, 0f, 90f));
                rotationDroite = true;
            }
            if(transform.rotation.eulerAngles.z.Equals(180))
            {
                Instantiate(fleche, transform.position, Quaternion.Euler(0f, 0f, 180f));
            }
            if (transform.rotation.eulerAngles.z.Equals(270))
            {
                Instantiate(fleche, transform.position, Quaternion.Euler(0f, 0f, -90f));
            }
            if (transform.rotation.eulerAngles.z.Equals(0))
            {
                Instantiate(fleche, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }

            time = 0;
        }
        
    }


}
