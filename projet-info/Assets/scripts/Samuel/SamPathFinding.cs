using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamPathfinding
{
    //cout des deux mouvements possibles
    private const int MOUVEMENT_DROIT = 10;
    private const int MOUVEMENT_DIAGONAL = 14;

    private Grid<SamNode> grid;
    private List<SamNode> listeOuverte;
    private List<SamNode> listeFerme;

    public SamPathfinding(int largeur, int hauteur, float dimCell, Vector3 origine)
    {
        grid = new Grid<SamNode>(largeur, hauteur, dimCell, origine,(Grid<SamNode> g, int x, int y) => new SamNode(g, x, y));
    }

    public List<SamNode> TrouverChemin(int debutX, int debutY, int finX, int finY)
    {
        SamNode caseDebut = grid.GetGridObject(debutX, debutY);
        SamNode caseFin = grid.GetGridObject(finX, finY);

        listeOuverte = new List<SamNode> { caseDebut };
        listeFerme = new List<SamNode>();

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
        caseDebut.hCost = CalculDistance(caseDebut, caseFin);
        caseDebut.calculFCost();

        while(listeOuverte.Count > 0)
        {
            SamNode currentNode = GetMinFCostNode(listeOuverte);
            if(currentNode == caseFin)
            {
                //si on a atteint la derniere case
                return CalculerChemin(caseFin);
            }

            listeOuverte.Remove(currentNode);
            listeFerme.Add(currentNode);

        foreach(SamNode caseVoisin in GetListVoisin(currentNode))
            {
                if (listeFerme.Contains(caseVoisin))
                {
                    continue;
                }

                int essaieGCost = currentNode.gCost + CalculDistance(currentNode, caseVoisin);
                if(essaieGCost < caseVoisin.gCost)
                {
                    caseVoisin.derniereCase = currentNode;
                    caseVoisin.gCost = essaieGCost;
                    caseVoisin.hCost = CalculDistance(caseVoisin, caseFin);
                    caseVoisin.calculFCost();

                    if (!listeOuverte.Contains(caseVoisin))
                    {
                        listeOuverte.Add(caseVoisin);

                    }
                }
            }
        }
        return null;
    }

    private List<SamNode> GetListVoisin(SamNode currentNode)
    {
        List<SamNode> listVoisin = new List<SamNode>();

        if(currentNode.x - 1 >= 0)
        {
            
        }
        return listVoisin;
    }

    private List<SamNode> CalculerChemin(SamNode caseFin)
    {
        return null;
    }
    
    private int CalculDistance(SamNode a, SamNode b)
    {
        int distanceX = Mathf.Abs(a.x - b.x);
        int distanceY = Mathf.Abs(a.y - b.y);
        int restant = Mathf.Abs(distanceX - distanceY);
        return MOUVEMENT_DIAGONAL * Mathf.Min(distanceX, distanceY) + MOUVEMENT_DROIT * restant;
    }
    
    private SamNode GetMinFCostNode(List<SamNode> pathNodeList)
    {
        SamNode minFCostNode = pathNodeList[0];
        for(int i = 1; i < pathNodeList.Count; i++)
        {
            if(pathNodeList[i].fCost < minFCostNode.fCost)
            {
                minFCostNode = pathNodeList[i];
            }
        }
        return minFCostNode;
    }
}
