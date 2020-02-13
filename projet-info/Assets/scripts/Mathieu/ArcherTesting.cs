using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTesting : MonoBehaviour
{
    // Start is called before the first frame update
    public int hauteur = 14;
    public int largeur = 22;
    public float dimCell = 0.5f;
    public float nbCaseDistance = 8f;
    private ArcherPathfinding pathfinding;
    List<MatNode> chemin;
    int index = 0;
    Vector3 positionSouris;
    public float speed = 5f;
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

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log("distance : "+distance);
        Debug.Log("case : "+ (nbCaseDistance * dimCell));
          if (distance <= (nbCaseDistance * dimCell))
            {
            
            cheminAtteint = false;
            pathfinding.limiteDistance = 0;
            pathfinding.getGrid().GetXY(transform.position, out int x1, out int y1);
            pathfinding.getGrid().GetXY(player.transform.position, out int x2, out int y2);
            index = 0;
            chemin = pathfinding.FindPath(x1, y1, x2, y2);
            SuivreChemin();

            }
            if(cheminAtteint != true ) SuivreChemin();


            SuivreChemin();


        if (chemin != null)
            {
                 for (int i = 0; i < chemin.Count - 1; i++)
                {

                    Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 100f);
                }

                



            }

        

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
