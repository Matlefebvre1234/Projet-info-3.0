using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementAiMathias : MonoBehaviour
{

    private PathfindingMathias pathfinding;
    private int x;
    private int y;

    public float vitesse = 0.001f;

    private float distanceMaxParcourue;

    private GameObject joueur;
    private GameObject ennemi;

    private Vector3 positionJoueur = new Vector3();

    private float tempsProchaineAction = 0.0f;
    public float periode = 0.1f;

    private List<CheminMathias> chemin;

    private int index = 1;

    private int posX;
    private int posY;

    private float x1;
    private float y1;

    private int xE;
    private int yE;

    private float dimCell = 0.5f;

    private GridMathias grille;

    private Vector3 origine = new Vector3(8, 1);

    private bool fin = false;

    private Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Niveau Difficulté") == 1)
        {
            transform.gameObject.GetComponent<Santé>().santeeMax = 100;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
        {
            transform.gameObject.GetComponent<Santé>().santeeMax = 125;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
        {
            transform.gameObject.GetComponent<Santé>().santeeMax = 150;
        }

        pathfinding = new PathfindingMathias();
        joueur = new GameObject();
        joueur = GameObject.FindGameObjectWithTag("Player");
        positionJoueur = joueur.transform.position;

        grille = GameObject.FindObjectOfType<GridMonstresMathias>().getGrid();
        index = 1;
        anim = GetComponent<Animator>();
        anim.SetFloat("Vitesse", 1);
    }

    void Update()
    {
        grille.GetXY(transform.position, out xE, out yE);
        grille.GetXY(positionJoueur, out posX, out posY);
        positionJoueur = joueur.transform.position;
        pathfinding.GetGrid().GetXY(positionJoueur, out x, out y);

        chemin = pathfinding.Chemin(xE, yE, posX, posY);
            if (fin == false)
            {
                tempsProchaineAction += periode;
                Mouvement();
            }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("Niveau Difficulté") == 1)
            {
                joueur.transform.GetComponent<Santé>().attaque(0.5f);
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
            {
                joueur.transform.GetComponent<Santé>().attaque(0.6f);
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
            {
                joueur.transform.GetComponent<Santé>().attaque(0.7f);
            }

        }
        anim.SetFloat("Vitesse", 0);
    }

    private void Mouvement()
    {

        if (chemin != null)
        {
            if(index >= 0 && index < chemin.Count)
            {
                Vector2 ajout = new Vector2(chemin[index].positionX, chemin[index].positionY);
                pathfinding.GetGrid().GetWorldXY(ajout, out x1, out y1);
                Vector2 destination = new Vector2(x1, y1);

                if (Vector2.Distance(transform.position, destination) > 0.01f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, destination, 2.0f*Time.deltaTime);
                }
            }
        }

    }

}
