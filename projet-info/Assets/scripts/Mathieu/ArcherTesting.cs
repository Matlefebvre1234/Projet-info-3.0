using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTesting : MonoBehaviour
{
    // Start is called before the first frame update
    public int hauteur = 14;
    public int largeur = 22;
    private ArcherPathfinding pathfinding;
    List<MatNode> chemin;
    int index = 0;
    Vector3 positionSouris;
    public float speed = 5f;
    void Start()
    {
        pathfinding = new ArcherPathfinding(largeur, hauteur);
        speed = speed * Time.deltaTime;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pathfinding.limiteDistance = 0;
            positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
     
            pathfinding.getGrid().GetXY(positionSouris, out int x2, out int y2);
            pathfinding.getGrid().GetXY(transform.position, out int x1, out int y1);

            chemin = pathfinding.FindPath(x1,y1, x2, y2);

            if (chemin != null)
            {
                // for (int i = 0; i < chemin.Count - 1; i++)
                //{
                //    Debug.Log(chemin[i].x + " , " + chemin[i].y + " G: " + chemin[i].Gcost + " h: " + chemin[i].Hcost + " F: " + chemin[i].Gcost);
                //    Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 100f);
                //}

                SuivreChemin();



            }

        

    }

    private void SuivreChemin()
    {
        if (chemin != null)
        {
            pathfinding.getGrid().GetWorldXY(new Vector2(chemin[index].x, chemin[index].y), out int x, out int y);
            Vector2 targetPosition = new Vector2(x, y);
            if (Vector2.Distance(transform.position, targetPosition) > 0.01f)
            {

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
            }
            else
            {
                index++;
                if (index >= chemin.Count)
                {
                    chemin = null;

                }
            }



        }
        

    }
}
