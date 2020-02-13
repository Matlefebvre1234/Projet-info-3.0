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
    private ArcherPathfinding pathfinding;
    public GameObject projectile;
    public float reloadTime = 0.5f;
    private float timeBeforeReaload = 0;
    List<MatNode> chemin;
    int index = 1;
    Vector3 positionSouris;
    
    GameObject player;
    bool cheminAtteint = false;

    void Start()
    {
        pathfinding = new ArcherPathfinding(largeur, hauteur);
        speed = speed * Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        timeBeforeReaload = timeBeforeReaload + 1 * Time.deltaTime;
        /* if (Input.GetMouseButtonDown(0))
         {
             pathfinding.limiteDistance = 0;
             positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             pathfinding.getGrid().GetXY(player.transform.position, out int x2, out int y2);
             pathfinding.getGrid().GetXY(transform.position, out int x1, out int y1);
             index = 0;
             chemin = pathfinding.FindPath(x1, y1, x2, y2);
             // chemin = pathfinding.FindPath(0, 0, x2, y2);
             SuivreChemin();
         }*/
        EloignerPlayer();
        if (timeBeforeReaload >= reloadTime)
        {
            TireArcher();
            timeBeforeReaload = 0;
        }
       
    }

   

  
        /*if (chemin != null)
        {
            for (int i = 0; i < chemin.Count - 1; i++)
            {

                Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 100f);
            }
        }*/




    

    private void TireArcher()
    {
        bool obstacle = false;
       Vector2 VecteurUnitaire = (Vector2)player.transform.position - (Vector2)transform.position;
        //VecteurUnitaire = VecteurUnitaire.normalized;
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, VecteurUnitaire);

        Debug.DrawRay(transform.position,VecteurUnitaire,Color.green,5f);
       for(int i =0;i<hit.Length;i++)
        {
            Debug.Log(hit[i].collider.gameObject.name);
            Debug.Log(hit.Length);
            if (hit[i].collider.gameObject.tag == "Obstacle")
            {
                obstacle = true;

            }
                
            

        }

       if(obstacle == false)
        {

            Instantiate(projectile, transform.position, Quaternion.identity);
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
            SuivreChemin();

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
                }
            }



        }
        

    } 
}
