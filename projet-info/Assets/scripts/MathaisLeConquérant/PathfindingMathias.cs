using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingMathias
{
    private Grid<CheminMathias> grille;
    private List<CheminMathias> listeOuverte;
    private List<CheminMathias> listeFermee;

    public PathfindingMathias(int largeur, int hauteur)
    {
        grille = new Grid<CheminMathias>(largeur, hauteur, 10f, Vector2.zero, (Grid<CheminMathias> grille, int x, int y) => new CheminMathias(grille, x, y));
    }

    private List<CheminMathias> Chemin(int debutX, int debutY, int finX, int finY)
    {
        CheminMathias caseDebut = grille.GetGridObject(debutX, debutY);

        listeOuverte = new List<CheminMathias>() { caseDebut };
        listeFermee = new List<CheminMathias>();

        for (int x = 0; x < grille.GetLargueur(); x++)
        {
            for(int y = 0; y < grille.GetHauteur(); y++)
            {
                CheminMathias pathNode = grille.GetGridObject(x, y);
                case.g = int.MaxValue;
            }
        }
    }
}
