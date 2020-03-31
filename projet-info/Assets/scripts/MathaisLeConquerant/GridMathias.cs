using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMathias : MonoBehaviour
{

    private int largeur;
    private int hauteur;
    private Vector3 origine;
    private float dimCell;
    private Vector3 positionJoueur;
    private positionJoueur posJ = new positionJoueur();
    private CheminMathias[,] listeCases;
    private GameObject[] listeObstacles;
    private GameObject[] listeLave;
    public List<CheminMathias> positionsObstacles;
    int positionXObs;
    int positionYObs;

    //Constructeur d'une gille qui reçoit une largeur, une hauteur, la dimension de ses différentes cases, ainsi que son origine
    public GridMathias(int n_largeur, int n_hauteur, float n_dimCell, Vector3 n_origine)
    {

        largeur = n_largeur;
        hauteur = n_hauteur;
        dimCell = n_dimCell;
        origine = n_origine;
        listeCases = new CheminMathias[largeur, hauteur];

        //Listes des différentes cases que l'intelligence artificielle ne peut traverser à cause d'obstacles
        listeObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        listeLave = GameObject.FindGameObjectsWithTag("PiegeAuSol");

        //Création de toutes les cases nécessaires pour couvrir toute la grille, il sera ainsi possible de stocker toutes les informations dont nous avons besoin dans chaque case de la grille
        for (int x = 0; x < listeCases.GetLength(0); x++)
        {
            for (int y = 0; y < listeCases.GetLength(1); y++)
            {
                listeCases[x, y] = new CheminMathias(x, y);
            }

        }

        //Toutes les cases où il y a un osbtacle que l'intelligence artificielle ne peut pas traverser vont être étiquetées
        for(int i = 0; i < listeObstacles.Length; i++)
        {
            GetXY(listeObstacles[i].transform.position, out positionXObs, out positionYObs);
            CheminMathias obstacles = GetGridObject(positionXObs, positionYObs);
            obstacles.SetObstacleTrue();
        }

        for (int i = 0; i < listeLave.Length; i++)
        {
            GetXY(listeLave[i].transform.position, out positionXObs, out positionYObs);
            CheminMathias lave = GetGridObject(positionXObs, positionYObs);
            lave.SetObstacleTrue();
        }
    }

    //Méthode qui transforme une position en Vector3 en valeur de x et de y qui correspondent à la grille créée
    public void GetXY(Vector3 position, out int x, out int y)
    {
        x = Mathf.FloorToInt((position.x / dimCell) - origine.x);
        y = Mathf.FloorToInt((position.y / dimCell) - origine.y);
    }

    //Getter qui retourne une case selon sa position en x et en y dans la grille
    public CheminMathias GetGridObject(int x, int y)
    {
            return listeCases[x, y];
    }
    
    //Getter qui retourne la largeur de la grille
    public int GetLargueur()
    {
        return largeur;
    }

    //Getter qui retourne la hauteur de la grille
    public int GetHauteur()
    {
        return hauteur;
    }

    //Getter qui retourne la dimension des cases de la grille
    public float GetDimCell()
    {
        return dimCell;
    }

    //Getter qui retourne une position en x et en y selon sa position en Vector3
    public void GetWorldXY(Vector3 position, out float x, out float y)
    {
        x = position.x * dimCell + 4.25f;
        y = position.y * dimCell + 0.75f;
    }
}
