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
    public float vitesse = 5f;
    public Vector2 targetPosition;

    public Vector3 posJoueur;
    public int compteur = 0;
    private float temps;
    private bool prendreDomage;

    private Santé domage;

    private GameObject[] projectile;
    private float angle;
    private float distanceX;
    private float distanceY;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(largeur, hauteur, dimCell, origine);
        samPathfinding = new SamPathfinding(largeur, hauteur, dimCell, origine);
        demon = new GameObject();
        joueur = new GameObject();
        demon = GameObject.FindGameObjectWithTag("Demon");
        joueur = GameObject.FindGameObjectWithTag("Player");
        cheminVecteur = new List<Vector3>();
        index = 1;
        cheminVecteur = samPathfinding.TrouverChemin(transform.position, joueur.transform.position);
        posJoueur = new Vector3();
        posJoueur = joueur.transform.position;
        domage = joueur.GetComponent<Santé>();
        prendreDomage = true;
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
        if (cheminVecteur != null)
        {
            if (!projectile.Length.Equals(0))
            {
                for (int i = 0; i < projectile.Length; i++)
                {
                    distanceX = Mathf.Abs(transform.position.x - projectile[i].transform.position.x);
                    distanceY = Mathf.Abs(transform.position.y - projectile[i].transform.position.y);
                    if (distanceX <= 2 && distanceY <= 2)
                    {
                        Vector2 vectorAngle;
                        vectorAngle = projectile[i].transform.position - transform.position;
                        angle = Mathf.Atan2(vectorAngle.y, vectorAngle.x);
                        angle = angle * Mathf.Rad2Deg;
                        Debug.Log("Angle :" + angle);
                        grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);

                        if ((angle > -20 && angle < 20) || (angle < -160 && angle > 160))
                        {
                            targetPosition = new Vector2(x, y + 1);
                        }
                        else if(angle >= 20 && angle <= 90)
                        {
                            targetPosition = new Vector2(x - 1, y + 1);
                        }
                        else if (angle > 90 && angle <= 160)
                        {
                            targetPosition = new Vector2(x - 1, y - 1);
                        }
                        else if (angle >= -160 && angle <= -90)
                        {
                            targetPosition = new Vector2(x - 1, y + 1);
                        }
                        else if (angle >= -90 && angle <= -20)
                        {
                            targetPosition = new Vector2(x + 1, y + 1);
                        }

                        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * vitesse);
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
