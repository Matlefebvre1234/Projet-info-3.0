using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamPathfinding
{
    //cout des deux mouvements possibles
    private const int MOUVEMENT_DROIT = 10;
    private const int MOUVEMENT_DIAGONAL = 14;

    private Grid grid;
    private List<SamNode> listeOuverte;
    private List<SamNode> listeFerme;

    public static SamPathfinding Instance { get; private set; }

    public SamPathfinding()
    {
        Instance = this;
        grid = GameObject.FindObjectOfType<GridDemon>().getGrid();
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
                if(caseVoisin.GetObstacle() == true)
                {
                    listeFerme.Add(caseVoisin);
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

    public List<Vector3> TrouverChemin(Vector3 positionDebut, Vector3 positionFin)
    {
        grid.GetXY(positionDebut, out int x, out int y);
        grid.GetXY(positionFin, out int x1, out int y1);

        List<SamNode> chemin = TrouverChemin(x, y, x1, y1);
        if(chemin == null)
        {
            return null;
        }
        else
        {
            List<Vector3> cheminVecteur = new List<Vector3>();
            foreach(SamNode pathNode in chemin) {

                cheminVecteur.Add(new Vector3(pathNode.x, pathNode.y));
            }
            return cheminVecteur;
        }
    }

    private List<SamNode> GetListVoisin(SamNode currentNode)
    {
        List<SamNode> listeVoisin = new List<SamNode>();

        if(currentNode.x - 1 >= 0)
        {
            //gauche
            listeVoisin.Add(GetCase(currentNode.x - 1, currentNode.y));

            //gauche haut
            if(currentNode.y + 1 < grid.GetHauteur())
            {
                listeVoisin.Add(GetCase(currentNode.x - 1, currentNode.y + 1));
            }

            //gauche bas
            if(currentNode.y - 1 >= 0)
            {
                listeVoisin.Add(GetCase(currentNode.x - 1, currentNode.y - 1));
            }
        }

        if(currentNode.x + 1 < grid.GetLargueur())
        {
            //droite
            listeVoisin.Add(GetCase(currentNode.x + 1, currentNode.y));

            //droite haut
            if(currentNode.y + 1 < grid.GetHauteur())
            {
                listeVoisin.Add(GetCase(currentNode.x + 1, currentNode.y + 1));
            }

            //droite bas
            if(currentNode.y - 1 >= 0)
            {
                listeVoisin.Add(GetCase(currentNode.x + 1, currentNode.y - 1));
            }
        }

        //haut
        if(currentNode.y + 1 < grid.GetHauteur())
        {
            listeVoisin.Add(GetCase(currentNode.x, currentNode.y + 1));
        }

        //bas
        if(currentNode.y - 1 >= 0)
        {
            listeVoisin.Add(GetCase(currentNode.x, currentNode.y - 1));
        }

        return listeVoisin;
    }

    private SamNode GetCase(int x, int y)
    {
        return grid.GetGridObject(x, y);
    }

    private List<SamNode> CalculerChemin(SamNode caseFin)
    {
        List<SamNode> chemin = new List<SamNode>();
        chemin.Add(caseFin);
        SamNode currentNode = caseFin;
        while(currentNode.derniereCase != null)
        {
            chemin.Add(currentNode.derniereCase);
            currentNode = currentNode.derniereCase;
        }
        chemin.Reverse();
        return chemin;
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
