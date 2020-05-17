using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementAiMathias : MonoBehaviour
{

    private AEtoileMathias pathfinding;
    private int x;
    private int y;

    private GameObject joueur;

    private Vector3 positionJoueur = new Vector3();

    private float tempsProchaineAction = 0.0f;
    public float periode = 0.1f;

    private List<Case> chemin;

    private int caseChemin = 1;

    private int xJ;
    private int yJ;

    private float xTemp;
    private float yTemp;

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
        //Sert aux changements de difficulté
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

        pathfinding = new AEtoileMathias();
        joueur = new GameObject();
        joueur = GameObject.FindGameObjectWithTag("Player");
        positionJoueur = joueur.transform.position;

        grille = GameObject.FindObjectOfType<GridMonstresMathias>().getGrid();
        anim = GetComponent<Animator>();
        anim.SetFloat("Vitesse", 1);
    }

    void Update()
    {
        grille.GetXY(transform.position, out xE, out yE);
        grille.GetXY(positionJoueur, out xJ, out yJ);
        positionJoueur = joueur.transform.position;

        chemin = pathfinding.Chemin(xE, yE, xJ, yJ);

        //Si le chemin n'est pas terminé, l'ennemi bouge
        if (fin == false)
        {
           Mouvement();
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //L'ennemi fait plus ou moins de dégâts dépendemment de la difficulté
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

    //Fonction qui permet à l'ennemi de bouger
    private void Mouvement()
    {

        if (chemin != null)
        {
                Vector2 ajout = new Vector2(chemin[caseChemin].positionX, chemin[caseChemin].positionY);
                pathfinding.GetGrid().GetWorldXY(ajout, out xTemp, out yTemp);
                Vector2 destination = new Vector2(xTemp, yTemp);

                if (Vector2.Distance(transform.position, destination) > 0.01f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, destination, 2.0f*Time.deltaTime);
                }

            else
            {
                fin = true;
            }
        }

    }

}
