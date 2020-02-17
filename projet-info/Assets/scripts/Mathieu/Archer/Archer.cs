using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    // Start is called before the first frame update
    public int hauteur = 14;
    public int largeur = 22;
    public float dimCell = 0.5f;
    public float nbCaseDistance = 8.0f;
    public float speed = 5f;
    private bool rapprochement = false;
    private ArcherPathfinding pathfinding;
    private matPathfinding pathfingRapprochement;
    public GameObject projectile;
    public float reloadTime = 0.5f;
    private float timeBeforeReaload = 0;
    private int nbTireManquer = 0;
    private float tempRapprochement = 0f;
    private bool tireEffectuer = false;


    List<MatNode> chemin;
    int index = 1;
    Vector3 positionSouris;
    
    GameObject player;
    bool cheminAtteint = false;

    void Start()
    {
        pathfinding = new ArcherPathfinding(largeur, hauteur);
        pathfingRapprochement = new matPathfinding(largeur, hauteur);
        speed = speed * Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
       
        Debug.Log(rapprochement);
      
        timeBeforeReaload = timeBeforeReaload + 1 * Time.deltaTime;
        if(rapprochement != true)EloignerPlayer();
        if (timeBeforeReaload >= reloadTime)
        {
            tireEffectuer = TireArcher();
           if (tireEffectuer == false) nbTireManquer++;

          if (nbTireManquer >= 7) rapprochement = true;
            
            timeBeforeReaload = 0;
        }
      if (rapprochement == true) RapprochementPlayer();

    }

    private void RapprochementPlayer()
    {

        bool obstacle = false;

        Vector2 VecteurUnitaire = (Vector2)player.transform.position - (Vector2)transform.position;
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, VecteurUnitaire);
        RaycastHit2D playerhit = new RaycastHit2D();
        List<RaycastHit2D> obstacleHit = new List<RaycastHit2D>();

       // Debug.DrawRay(transform.position, VecteurUnitaire, Color.green, 5f);

        for (int i = 0; i < hit.Length; i++)
        {

            if (hit[i].collider.gameObject.tag == "Obstacle")
            {

                obstacleHit.Add(hit[i]);

            }


            if (hit[i].collider.gameObject.tag == "Player")
            {

                playerhit = hit[i];

            }

        }


        if (obstacleHit.Count != 0)
        {

            for (int k = 0; k < obstacleHit.Count; k++)
            {



                if (playerhit.distance < obstacleHit[k].distance)
                {

                    obstacle = true;
                    tempRapprochement += 1 * Time.deltaTime;
                    if (tempRapprochement >= 3f)
                    {
                        rapprochement = false;
                        tempRapprochement = 0f;
                    }
                }

            }

        }
        else
        {

            obstacle = true;
            tempRapprochement += 1 * Time.deltaTime;
            if (tempRapprochement >= 3f)
            {
                rapprochement = false;
                tempRapprochement = 0f;
            } 

        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if ( obstacle != true)
        {
           
                cheminAtteint = false;
            
                pathfingRapprochement.getGrid().GetXY(transform.position, out int x1, out int y1);
                pathfingRapprochement.getGrid().GetXY(player.transform.position, out int x2, out int y2);
                index = 1;
                chemin = pathfingRapprochement.FindPath(x1, y1, x2, y2);
              

            

            SuivreChemin();
        }
        else {
            chemin = null;
            nbTireManquer = 0;
            tempRapprochement += 1 * Time.deltaTime;
            if (tempRapprochement >= 3f)
            {
                rapprochement = false;
                tempRapprochement = 0f;
            }

            Debug.Log("arret"); }

     
    }

    private bool TireArcher()
    {
        bool obstacle = false;

        Vector2 VecteurUnitaire = (Vector2)player.transform.position - (Vector2)transform.position;
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, VecteurUnitaire);
        RaycastHit2D playerhit = new RaycastHit2D();
        List<RaycastHit2D> obstacleHit = new List<RaycastHit2D>();

       Debug.DrawRay(transform.position, VecteurUnitaire, Color.red, 5f);

        for (int i = 0; i < hit.Length; i++)
        {

            if (hit[i].collider.gameObject.tag == "Obstacle")
            {
                
                obstacleHit.Add(hit[i]);

            }


            if (hit[i].collider.gameObject.tag == "Player")
            {
               
                playerhit = hit[i];

            }

        }


        if (obstacleHit.Count != 0)
        {

            for (int k = 0; k < obstacleHit.Count; k++)
            {
                


                if (playerhit.distance < obstacleHit[k].distance)
                {

                    obstacle = true;
                }

            }

        }
        else
        {

            obstacle = true;

        }



        if (obstacle == true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            return true;
        }

        else
        {
            return false;

        }

    }

    private void EloignerPlayer()
    {
        
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= (nbCaseDistance * dimCell))
        {

            cheminAtteint = false;
            pathfinding.limiteDistance = 0;
            pathfinding.getGrid().GetXY(transform.position, out int x1, out int y1);
            pathfinding.getGrid().GetXY(player.transform.position, out int x2, out int y2);
            index = 1;
            chemin = pathfinding.FindPath(x1, y1, x2, y2);
           

        }

        SuivreChemin();
    }

    private void SuivreChemin()
    {
        if (chemin != null)
        {
            
            pathfinding.getGrid().GetWorldXY(new Vector2(chemin[index].x, chemin[index].y), out float x, out float y);
            Vector2 targetPosition = new Vector2(x, y);

            if (Vector2.Distance(transform.position, targetPosition) > 0.0001f)
            {

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
            }
            else
            {
                index++;
                if (index >= chemin.Count)
                {
                    chemin = null;
                    index = 0;
                    cheminAtteint = true;

                    tempRapprochement += 1 * Time.deltaTime;
                    if (tempRapprochement >= 3f) rapprochement = false;
                    tempRapprochement = 0;
                    nbTireManquer = 0;
                }
            }



        }
        

    } 
}
