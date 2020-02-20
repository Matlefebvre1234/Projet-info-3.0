using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public float rangeExplosion = 0.2f;

    private float distance;

    GameObject player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        //if (distance < rangeExplosion && animator.GetBool("collision") == false)
        //{
        //    //Explosion et dégats
        //    animator.SetBool("collision", true);
        //    player.GetComponent<Santé>().attaque(15);
        //}
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mine Animation"))
        {
            ExplosionIsEnd();
        }
    }

    private void  OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //Explosion et dégats
            animator.SetBool("collision", true);
            player.GetComponent<Santé>().attaque(15);
        }

    }

    public void ExplosionIsEnd()
    {
        animator.SetBool("collision", false);
        Destroy(transform.gameObject);
    }
}
