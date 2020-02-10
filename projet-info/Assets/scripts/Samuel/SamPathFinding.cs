using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamPathfinding
{
    //cout des deux mouvements possibles
    private const int MOUVEMENT_DROIT = 10;
    private const int MOUVEMENT_DIAGONAL = 14;

    private Grid<SamNode> grid;
    private List<SamNode> listOuverte;
    private List<SamNode> listFerme;

    public SamPathfinding(int largeur, int hauteur, float dimCell, Vector3 origine)
    {
        grid = new Grid<SamNode>(largeur, hauteur, dimCell, origine,(Grid<SamNode> g, int x, int y) => new SamNode(g, x, y));
    }

    private List<SamNode> TrouverChemin(int debutX, int debutY, int finX, int finY)
    {
        SamNode caseDebut = grid.GetGridObject(debutX, debutY);

        listOuverte = new List<SamNode> { caseDebut };
        listFerme = new List<SamNode>();

        for (int x = 0; x < grid.GetLargueur(); x++)
        {
            for(int y = 0; y < grid.GetHauteur(); y++)
            {
                SamNode chemin = grid.GetGridObject(x, y);
                chemin.gCost = int.MaxValue;
                chemin.calculFCost();
                chemin.derniereCase = null;
            }
        }

        caseDebut.gCost = 0;
    }
    /*
    private int CalculDistance(SamNode a, SamNode b)
    {
        int distanceX = Mathf.Abs(a. - b.x);
    }
    */
}
