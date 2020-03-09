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
    private Vector3 lastPosDemon;

    private GameObject[] projectile;

    private Santé domage;

    //Pour eviter les projectiles
    public float vuRad;
    [Range(0,360)]
    public float vuAngle;
    private int AngleDir;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    [HideInInspector]
    public List<Transform> cibleVisisble = new List<Transform>();


    private float distanceX = 0f;
    private float distanceY = 0f;
    private float esquiveX = 0f;
    private float esquiveY = 0f;
    private float angleProj = 0f;
    private Vector2 distance;
    private int compteur = 0;

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

        //Direction de la vu
        if(transform.position.x >= lastPosDemon.x && transform.position.y == lastPosDemon.y)
        {
            AngleDir = 90;
            lastPosDemon = transform.position;
        }
        else if(transform.position.x > lastPosDemon.x && transform.position.y > lastPosDemon.y)
        {
            AngleDir = 45;
            lastPosDemon = transform.position;
        }
        else if (transform.position.x == lastPosDemon.x && transform.position.y > lastPosDemon.y)
        {
            AngleDir = 0;
            lastPosDemon = transform.position;
        }
        else if (transform.position.x < lastPosDemon.x && transform.position.y > lastPosDemon.y)
        {
            AngleDir = -45;
            lastPosDemon = transform.position;
        }

        else if (transform.position.x < lastPosDemon.x && transform.position.y == lastPosDemon.y)
        {
            AngleDir = -90;
            lastPosDemon = transform.position;
        }
        else if (transform.position.x < lastPosDemon.x && transform.position.y < lastPosDemon.y)
        {
            AngleDir = -135;
            lastPosDemon = transform.position;
        }
        else if (transform.position.x == lastPosDemon.x && transform.position.y < lastPosDemon.y)
        {
            AngleDir = -180;
            lastPosDemon = transform.position;
        }
        else if (transform.position.x > lastPosDemon.x && transform.position.y < lastPosDemon.y)
        {
            AngleDir = 135;
            lastPosDemon = transform.position;
        }
        //TrouverProjectileVisibles();
    }
    private void Mouvement()
    {
        esquiveX = 0f;
        esquiveY = 0f;
        if (cheminVecteur != null)
        {
            if (!projectile.Length.Equals(0))
            {
                
                for (int k = 0; k < projectile.Length; k++)
                {
                    //Physics2D.Raycast(transform.position, projectile[k].transform.position, 1f);
                    distanceX = projectile[k].transform.position.x - transform.position.x;
                    distanceY = projectile[k].transform.position.y - transform.position.y;
                    distance = (projectile[k].transform.position - transform.position).normalized;
                    angleProj = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
                    Debug.Log(angleProj);
                    //Debug.Log(k);
                    if (Mathf.Abs(distanceX) < 1f && Mathf.Abs(distanceY) < 1f)
                    {
                        if ((angleProj > -20 && angleProj < 20) || (angleProj > 160 && angleProj < -160))
                        {
                            
                            //esquiveY = 4f;
                            //esquiveX = 4f;
                        }
                        
                        grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                        targetPosition = new Vector2(x + esquiveX, y + esquiveY);
                    }
                    else
                    {
                        grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                        targetPosition = new Vector2(x, y);
                    }

                    //if (Mathf.Abs(distanceX) < 1f && Mathf.Abs(distanceY) < 1f)
                    //{
                    /*if (distanceX < 0)
                    {
                        esquiveX = 2f;
                    }
                    else if (distanceX > 0)
                    {
                        esquiveX = -2f;
                    }
                    if (distanceY < 0)
                    {
                        esquiveY = 2f;
                    }
                    else if (distanceY > 0)
                    {
                        esquiveY = 2f;
                    }
                    if (distanceX < 1 && distanceY < 1)
                    {
                        grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                        targetPosition = new Vector2(x + esquiveX, y + esquiveY);
                    }
                    else
                    {
                        grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                        targetPosition = new Vector2(x, y);
                    }*/
                    //}
                }
                
            }
            else
            {
                grid.GetPositionMapXY(new Vector2(cheminVecteur[index].x, cheminVecteur[index].y), out float x, out float y);
                targetPosition = new Vector2(x, y);

            }

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

    void TrouverProjectileVisibles()
    {
        cibleVisisble.Clear();
        
        Collider[] projectileEnVu = Physics.OverlapSphere(transform.position, vuRad, targetMask);

        for(int i = 0; i < projectileEnVu.Length; i++)
        {
            
            Transform target = projectileEnVu[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;
            Debug.Log("hello");

            if (Vector3.Angle(transform.forward, dirToTarget) < vuAngle / 2)
            {
                
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    cibleVisisble.Add(target);
                }
            }
        }
    }

    public Vector2 DirAngle(float angleDegre, bool angleEstGlobal)
    {
        if (!angleEstGlobal)
        {
            angleDegre += transform.eulerAngles.y + AngleDir;
        }
        return new Vector2(Mathf.Sin(angleDegre * Mathf.Deg2Rad), Mathf.Cos(angleDegre * Mathf.Deg2Rad));
    }
}
