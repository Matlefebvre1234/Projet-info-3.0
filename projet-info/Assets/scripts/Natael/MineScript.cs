using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public float rangeExplosion = 0.5f;

    private float distance;
    private float elapseTime = 0;
    private int time;
    private bool explosion = false;

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
        elapseTime += Time.deltaTime;
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < rangeExplosion)
        {
            //Explosion et dégats
            animator.SetBool("collision", true);
        }
    }

    public void ExplosionIsEnd()
    {
        animator.SetBool("collision", false);
        Destroy(transform.gameObject);
        explosion = false;
    }
}
