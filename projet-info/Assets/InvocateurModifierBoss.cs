using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocateurModifierBoss : MonoBehaviour
{
 
    private SpriteRenderer spriterenderer;
    private Animator animator;
    public GameObject projectile;
    public float reloadTime = 20f;
    private float timeBeforeReaload = 0;
    public GameObject InvocateurInvoque;
    public int nombreMaxInvocateur = 2;
    public int nombreInvocateurPresent = 0;
    private BossInvocateur bossInvocateurScript;
    public List<GameObject> spawnPoints;






    List<MatNode> chemin;
    int index = 1;
    Vector3 positionSouris;

    GameObject player;
    bool cheminAtteint = false;

    void Start()
    {
        resetScript();
        nombreMaxInvocateur = 2;
        bossInvocateurScript = GetComponent<BossInvocateur>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

    }



    private void Update()
    {
        flipSprite();

        timeBeforeReaload = timeBeforeReaload + 1 * Time.deltaTime;
    

        if (timeBeforeReaload >= reloadTime  && nombreInvocateurPresent < nombreMaxInvocateur)
        {

            Invoquer();
            timeBeforeReaload = 0;
        }
        if (nombreMaxInvocateur <= 0)
        {
            bossInvocateurScript.ChangerScript();
            
        }


    }


    public void Invoquer()
    {
        animator.SetBool("attack", true);



    }

    private void stopAttackAnimation()
    {
        animator.SetBool("attack", false);
        int nbRandomSpawn = Mathf.CeilToInt(UnityEngine.Random.Range(0.1f,spawnPoints.Count - 1));
        float nbRandomX = UnityEngine.Random.Range(-0.5f, 0.5f);
        float nbRandomY = UnityEngine.Random.Range(-0.5f, 0.5f);
       
            
            GameObject Invocateur2 = Instantiate(InvocateurInvoque, spawnPoints[nbRandomSpawn].transform.position + new Vector3(nbRandomX, nbRandomY, 0), Quaternion.identity);
        InvocateurInvoque scriptInvocateur = Invocateur2.GetComponent<InvocateurInvoque>();
        scriptInvocateur.setInvocateur(gameObject);

        nombreInvocateurPresent++;
    }

   
    public void flipSprite()
    {

        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if ((angle < 90 && angle >= 0) || (angle > -90 && angle < 0))
        {
            spriterenderer.flipX = false;

        }

        if ((angle > 90 && angle < 180) || (angle > -180 && angle < -90))
        {
            spriterenderer.flipX = true;

        }


    }

    public void InvoquateurMeure()
    {
        nombreInvocateurPresent -= 1;
        nombreMaxInvocateur -= 1;

    }

    public void resetScript()
    {
        nombreMaxInvocateur = 2;
        nombreInvocateurPresent = 0;

    }
}

