using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMouvement : MonoBehaviour
{
    //PathFinding
    private Grid grid;
    public GameObject joueur;
    public Vector3 posJoueur;
    public SamPathfinding samPathfinding;
    public List<Vector3> cheminVecteur;
    private int index;
    public float vitesse = 2f;
    public Vector2 targetPosition;

    //Santé et dommage
    private Santé dommage;
    public int fireDommage = 20;
    public float sante = 30f;

    //Esquive
    private GameObject[] projectile;
    private Vector3 direction;
    private float distanceX = 0f;
    private float distanceY = 0f;
    private float esquiveX = 0f;
    private float esquiveY = 0f;
    private float angleProj;
    private float dirX;
    private float dirY;
    

    //Animation
    public Animator animator;
    private Vector3 gd;

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.FindObjectOfType<GridDemon>().getGrid();
        joueur = GameObject.FindGameObjectWithTag("Player");
        posJoueur = new Vector3();
        samPathfinding = new SamPathfinding();
        cheminVecteur = new List<Vector3>();
        index = 0;
        posJoueur = joueur.transform.position;
        dommage = joueur.transform.GetComponent<Santé>();
        cheminVecteur = samPathfinding.TrouverChemin(transform.position, joueur.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //grid.GetXY(transform.position, out int x, out int y);
        //grid.GetXY(joueur.transform.position, out int x1, out int y1);
        projectile = GameObject.FindGameObjectsWithTag("Projectile");

        //Animation
        gd = (joueur.transform.position - transform.position).normalized;
        Anim(gd);

        //Tracer le chemin (visualisation)
        /*if (chemin != null)
        {
            for (int i = 0; i < chemin.Count - 1; i++)
            {
                Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * dimCell + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 5f);
            }
        }*/

        if (grid.GetVector(posJoueur) != grid.GetVector(joueur.transform.position))
        {
            cheminVecteur = samPathfinding.TrouverChemin(transform.position, joueur.transform.position);
            posJoueur = joueur.transform.position;
            index = 1;
            Mouvement();
        }
        else
        {
            Mouvement();
        }
    }

    private void Mouvement()
    {
        esquiveX = 0f;
        esquiveY = 0f;
        if (cheminVecteur != null && index < cheminVecteur.Count)
        {
            if (!projectile.Length.Equals(0))
            {

                for (int k = 0; k < projectile.Length; k++)
                {
                    direction = projectile[k].GetComponent<projectileJ>().VecteurUnitaire;
                    dirX = direction.x;
                    dirY = direction.y;
                    distanceX = Mathf.Abs(projectile[k].transform.position.x - transform.position.x);
                    distanceY = Mathf.Abs(projectile[k].transform.position.y - transform.position.y);
                    angleProj = Mathf.Atan2(distanceY, distanceX) * Mathf.Rad2Deg;

                    if(distanceX <= 1.5 && distanceY <= 1.5)
                    {
                        if ((angleProj > -20 && angleProj < 20))
                        {
                            //(-1,1)
                            if ((dirX >= -1 && dirX < 0) && (dirY <= 1 && dirY > 0))
                            {
                                esquiveX = -1f;
                                esquiveY = -1f;
                            }
                            //(-1,-1)
                            else if ((dirX >= -1 && dirX < 0) && (dirY >= -1 && dirY < 0))
                            {
                                esquiveX = -1f;
                                esquiveY = 1f;
                            }
                            else
                            {
                                esquiveX = 0f;
                                esquiveY = -1f;
                            }
                        }
                        else if (angleProj >= 20 && angleProj < 70)
                        {
                            //(-1,1)
                            if ((dirX >= -1 && dirX < 0) && (dirY <= 1 && dirY > 0))
                            {
                                esquiveX = -1f;
                                esquiveY = -1f;
                            }
                            //(0,-1)
                            else if(dirX == 0 && dirY == -1)
                            {
                                esquiveX = -1f;
                                esquiveY = 0f;
                            }
                            //(-1,0)
                            else if(dirX == -1 && dirY == 0)
                            {
                                esquiveX = 0f;
                                esquiveY = -1f;
                            }
                            else
                            {
                                esquiveX = -1f;
                                esquiveY = 1f;
                            }
                        }
                        else if ((angleProj > 70 && angleProj < 110))
                        {
                            //(0,-1)
                            if(dirX == 0 && dirY == -1)
                            {
                                esquiveX = 1f;
                                esquiveY = 0f;
                            }
                            //(-1,-1)
                            else if(dirX >= -1 && dirX < 0 && dirY >= -1 && dirY < 0)
                            {
                                esquiveX = -1f;
                                esquiveY = 1f;
                            }
                            //(1,-1)
                            else if ((dirX <= 1 && dirX > 0) && (dirY >= -1 && dirY < 0))
                            {
                                esquiveX = 1f;
                                esquiveY = 1f;
                            }
                        }
                        else if (angleProj >= 110 && angleProj <= 160)
                        {
                            //(1,-1)
                            if ((dirX >= 1 && dirX < 0) && (dirY <= -1 && dirY > 0))
                            {
                                esquiveX = 1f;
                                esquiveY = 1f;
                            }
                            //(0,-1)
                            else if (dirX == 0 && dirY == -1)
                            {
                                esquiveX = 1f;
                                esquiveY = 0f;
                            }
                            //(1,0)
                            else if (dirX == 1 && dirY == 0)
                            {
                                esquiveX = 0f;
                                esquiveY = -1f;
                            }
                            else
                            {
                                esquiveX = -1f;
                                esquiveY = -1f;
                            }
                        }
                        else if((angleProj > 160 || angleProj < -160))
                        {
                            //(1,1)
                            if ((dirX <= 1 && dirX > 0) && (dirY <= 1 && dirY > 0))
                            {
                                esquiveX = 1f;
                                esquiveY = -1f;
                            }
                            //(1,-1)
                            else if ((dirX <= 1 && dirX > 0) && (dirY >= -1 && dirY < 0))
                            {
                                esquiveX = 1f;
                                esquiveY = 1f;
                            }
                            else
                            {
                                esquiveX = 0f;
                                esquiveY = 1f;
                            }
                        }
                        else if (angleProj > -160 && angleProj < -110)
                        {
                            //(1,1)
                            if ((dirX >= 1 && dirX < 0) && (dirY <= -1 && dirY > 0))
                            {
                                esquiveX = 1f;
                                esquiveY = 1f;
                            }
                            //(0,1)
                            else if (dirX == 0 && dirY == 1)
                            {
                                esquiveX = 1f;
                                esquiveY = 0f;
                            }
                            //(1,0)
                            else if (dirX == 1 && dirY == 0)
                            {
                                esquiveX = 0f;
                                esquiveY = 1f;
                            }
                            else
                            {
                                esquiveX = -1f;
                                esquiveY = -1f;
                            }
                        }
                        else if((angleProj > -110 && angleProj < -70))
                        {
                            //(0,1)
                            if (dirX == 0 && dirY == 1)
                            {
                                esquiveX = 1f;
                                esquiveY = 0f;
                            }
                            //(-1,1)
                            else if (dirX >= -1 && dirX < 0 && dirY >= 1 && dirY < 0)
                            {
                                esquiveX = 1f;
                                esquiveY = 1f;
                            }
                            //(1,1)
                            else if ((dirX <= 1 && dirX > 0) && (dirY >= 1 && dirY < 0))
                            {
                                esquiveX = -1f;
                                esquiveY = 1f;
                            }
                        }
                        else if (angleProj >= -70 && angleProj < -20)
                        {
                            //(-1,1)
                            if ((dirX >= -1 && dirX < 0) && (dirY <= 1 && dirY > 0))
                            {
                                esquiveX = -1f;
                                esquiveY = -1f;
                            }
                            //(0,1)
                            if (dirX == 0 && dirY == 1)
                            {
                                esquiveX = -1f;
                                esquiveY = 0f;
                            }
                            //(-1,0)
                            else if (dirX == -1 && dirY == 0)
                            {
                                esquiveX = 0f;
                                esquiveY = 1f;
                            }
                            else
                            {
                                esquiveX = 1f;
                                esquiveY = 1f;
                            }
                        }
                        grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                        targetPosition = new Vector2(x + esquiveX, y + esquiveY);
                        if (Vector2.Distance(transform.position, targetPosition) > 0.001f)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * (vitesse + 0.5f));
                        }
                        else
                        {
                            index++;
                        }

                    }
                    else
                    {
                        
                        if (k < 1)
                        {
                            grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                            targetPosition = new Vector2(x, y);
                            if (Vector2.Distance(transform.position, targetPosition) > 0.001f)
                            {
                                transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * vitesse);
                            }
                            else
                            {
                                index++;
                            }
                        }
                    }
                        
                    

                }
            }
            else
            {
                grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                targetPosition = new Vector2(x, y);
                if (Vector2.Distance(transform.position, targetPosition) > 0.001f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * vitesse);
                }
                else
                {
                    index++;
                }
            }

        }
            
    }

    //Attaque
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            animator.SetTrigger("attaque");
            dommage.attaque(fireDommage * Time.deltaTime);
        }
    }

    //Animation
    private void Anim(Vector3 dir)
    {
        if(dir.x > 0)
        {
            animator.SetTrigger("droit");
            animator.SetTrigger("walking");
        }
        else if(dir.x < 0)
        {
            animator.SetTrigger("gauche");
            animator.SetTrigger("walking");
        }
        else
        {
            animator.SetTrigger("aucun");
        }
    }
}
