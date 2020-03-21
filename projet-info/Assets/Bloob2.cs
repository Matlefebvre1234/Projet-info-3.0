using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloob2 : MonoBehaviour
{
    private float speed = 5f;
    public float speedInitial = 5f;
    private matPathfinding pathfingRapprochement;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    private Invocateur invocateur;
     
    


    List<MatNode> chemin;
    int index = 1;
    Vector3 positionSouris;

    GameObject player;
    bool cheminAtteint = false;

    void Start()
    {
        
        pathfingRapprochement = new matPathfinding();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();



        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        flipSprite();
        speed = speedInitial;
        speed = speed * Time.deltaTime;
        RapprochementPlayer();
    }

    

    private void RapprochementPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

            if(transform.position != player.transform.position && distance > 0.5f )
        {


            cheminAtteint = false;

            pathfingRapprochement.getGrid().GetXY(transform.position, out int x1, out int y1);
            pathfingRapprochement.getGrid().GetXY(player.transform.position, out int x2, out int y2);
            index = 1;
            chemin = pathfingRapprochement.FindPath(x1, y1, x2, y2);

            SuivreChemin();


        }


    }

   

   

    private void SuivreChemin()
    {
        Debug.Log(index);
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (chemin != null && distance > 0.55f)
        {

            if (index >=1 && index < chemin.Count )
            {
                pathfingRapprochement.getGrid().GetWorldXY(new Vector2(chemin[index].x, chemin[index].y), out float x, out float y);
                Vector2 targetPosition = new Vector2(x, y);

                if (Vector2.Distance(transform.position, targetPosition) > 0.25f)
                {

                    transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
                }
                else
                {
                    index++;
                   
                    
                        chemin = null;

                        index = 1;
                        cheminAtteint = true;


                    
                }




            }



        }


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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        chemin = null;
    }

   

    public void setInvocateur(GameObject idInvocateur)
    {

        invocateur = idInvocateur.GetComponent<Invocateur>();

    }
}
