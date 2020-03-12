using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMouvement : MonoBehaviour
{
    private int hauteur = 14;
    private int largeur = 22;
    private float dimCell = 0.5f;
    private Vector3 origine = new Vector3(8, 1);
    private Grid grid;
    public GameObject joueur;
    public SamPathfinding samPathfinding;
    public GameObject demon;
    public List<Vector3> cheminVecteur;
    public int index;
    public float vitesse = 2f;
    public Vector2 targetPosition;

    public Vector3 posJoueur;
    private Vector3 lastPosDemon;

    private GameObject[] projectile;

    private Santé domage;

    private float distanceX = 0f;
    private float distanceY = 0f;
    private float esquiveX = 0f;
    private float esquiveY = 0f;
    private float angleProj;
    private Vector2 heading;
    private float distance;
    private Vector2 direction;

    public float sante = 30f;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(largeur, hauteur, dimCell, origine);
        samPathfinding = new SamPathfinding(largeur, hauteur, dimCell, origine);
        demon = GameObject.FindGameObjectWithTag("Demon");
        joueur = GameObject.FindGameObjectWithTag("Player");
        cheminVecteur = new List<Vector3>();
        index = 0;
        cheminVecteur = samPathfinding.TrouverChemin(transform.position, joueur.transform.position);
        posJoueur = new Vector3();
        posJoueur = joueur.transform.position;
        domage = joueur.GetComponent<Santé>();
        lastPosDemon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            grid.GetXY(demon.transform.position, out int x, out int y);
            grid.GetXY(joueur.transform.position, out int x1, out int y1);
            projectile = GameObject.FindGameObjectsWithTag("Projectile");

            List<SamNode> chemin = samPathfinding.TrouverChemin(x, y, x1, y1);
            if (chemin != null)
            {
                for (int i = 0; i < chemin.Count - 1; i++)
                {
                    //Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * dimCell + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 5f);
                }
            }



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
        int compteur = 0;
        if (cheminVecteur != null)
        {
            if (!projectile.Length.Equals(0))
            {

                for (int k = 0; k < projectile.Length; k++)
                {
                    distanceX = projectile[k].transform.position.x - transform.position.x;
                    distanceY = projectile[k].transform.position.y - transform.position.y;
                    heading = (projectile[k].transform.position - transform.position).normalized;
                    distance = heading.magnitude;
                    direction = heading / distance;
                    angleProj = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;

                    Debug.Log(direction);

                    //if (Physics2D.Raycast(projectile[k].transform.position, direction, 2f))
                    {
                        if (Mathf.Abs(distanceX) < 1.5f && Mathf.Abs(distanceY) < 1.5f)
                        {
                            if ((angleProj > -20 && angleProj < 20) || (angleProj > 160 && angleProj < -160))
                            {
                                esquiveX = 0f;
                                esquiveY = -1f;
                            }
                            else if ((angleProj > 70 && angleProj < 110) || (angleProj > -110 && angleProj < -70))
                            {
                                esquiveX = 1f;
                                esquiveY = 0f;
                            }
                            else if (angleProj >= 20 && angleProj < 70)
                            {
                                esquiveX = -1f;
                                esquiveY = -1f;
                            }
                            else if (angleProj >= 110 && angleProj <= 160)
                            {
                                esquiveX = 1f;
                                esquiveY = -1f;
                            }
                            else if (angleProj > -160 && angleProj < -110)
                            {
                                esquiveX = 1f;
                                esquiveY = -1f;
                            }
                            else if (angleProj >= -70 && angleProj < -20)
                            {
                                esquiveX = 1f;
                                esquiveY = -1f;
                            }
                        }
                    }

                    grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                    targetPosition = new Vector2(x + esquiveX, y + esquiveY);
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name.Equals("player")){
            cheminVecteur = null;
            index = 0;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("player"))
        {
            domage.attaque(20 * Time.deltaTime);
        }
    }

   
}
