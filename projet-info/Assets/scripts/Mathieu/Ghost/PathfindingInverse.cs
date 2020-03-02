using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingInverse
{

    public float dimCell = 0.5f;
    private Vector3 origine = new Vector3(8, 1);
    private MatGrid grid;
    private List<MatNode> openList;
    private List<MatNode> closeList;
    public int limiteDistance = 0;


    private const int COUT_MOUVEMENT_DROIT = 10;
    private const int COUT_MOUVEMENT_DIAGONAL = 14;


    public PathfindingInverse()
    {
        grid = GameObject.FindObjectOfType<GrilleMonstresMat>().getGrid();

    }

 
    private List<MatNode> GetNodeVoisin(MatNode nodeActuelle)
    {
        List<MatNode> listVoisins = new List<MatNode>();
        if (nodeActuelle.x - 1 >= 0)
        {
            // gauche
            listVoisins.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y));
            // gauche en bas
            if (nodeActuelle.y - 1 >= 0) listVoisins.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y - 1));
            // gauche en haut
            if (nodeActuelle.y + 1 < grid.GetHauteur()) listVoisins.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y + 1));
        }
        if (nodeActuelle.x + 1 < grid.GetLargueur())
        {
            // droite
            listVoisins.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y));
            // droite bas
            if (nodeActuelle.y - 1 >= 0) listVoisins.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y - 1));
            // droite haut
            if (nodeActuelle.y + 1 < grid.GetHauteur()) listVoisins.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y + 1));
        }
        // bas
        if (nodeActuelle.y - 1 >= 0) listVoisins.Add(grid.GetGridObject(nodeActuelle.x, nodeActuelle.y - 1));
        // haut
        if (nodeActuelle.y + 1 < grid.GetHauteur()) listVoisins.Add(grid.GetGridObject(nodeActuelle.x, nodeActuelle.y + 1));

        return listVoisins;


    }

    public List<MatNode> CalculerCheminDeNode(MatNode endNode)
    {
        List<MatNode> chemin = new List<MatNode>();
        chemin.Add(endNode);
        MatNode nodeActuelle = endNode;

        while (nodeActuelle.cameFromNode != null)
        {
            chemin.Add(nodeActuelle.cameFromNode);
            nodeActuelle = nodeActuelle.cameFromNode;
        }
        chemin.Reverse();
        return chemin;

    }


    public List<MatNode> FindPath(int startX, int startY, int endX, int endY)
    {
        MatNode startNode = grid.GetGridObject(startX, startY);
        MatNode endNode = grid.GetGridObject(endX, endY);

        openList = new List<MatNode> { startNode };
        closeList = new List<MatNode>();

        for (int x = 0; x < grid.GetLargueur(); x++)
        {
            for (int y = 0; y < grid.GetHauteur(); y++)
            {
                MatNode node = grid.GetGridObject(x, y);
                node.Gcost = int.MaxValue;
                node.Hcost = 0;
                node.cameFromNode = null;
                node.CalculerFcost();

            }

        }
        startNode.Gcost = 0;
        startNode.Hcost = CalculerLaDistanceEntreNode(startNode, endNode);
        startNode.CalculerFcost();

        while (openList.Count > 0)
        {
            MatNode NodeActuelle = CalculerPlusGrandHcost(openList);
            limiteDistance++;

            if (limiteDistance >= 50) return CalculerCheminDeNode(NodeActuelle); //fin de la recherche



            openList.Remove(NodeActuelle);
            closeList.Add(NodeActuelle);

            foreach (MatNode nodeVoisine in GetNodeVoisin(NodeActuelle))
            {
                if (closeList.Contains(nodeVoisine)) continue;
                if (nodeVoisine.obstacle == true)
                {
                    closeList.Add(nodeVoisine);
                    continue;
                }


                int tempGcost = NodeActuelle.Gcost + CalculerLaDistanceEntreNode(NodeActuelle, nodeVoisine);
                if (tempGcost < nodeVoisine.Gcost)
                {
                    nodeVoisine.Gcost = tempGcost;
                    nodeVoisine.Hcost = CalculerLaDistanceEntreNode(nodeVoisine, endNode);
                    nodeVoisine.cameFromNode = NodeActuelle;
                    nodeVoisine.CalculerFcost();

                    if (!openList.Contains(nodeVoisine))
                    {
                        openList.Add(nodeVoisine);

                    }

                }

            }
        }
        //lorsque que la openlist est vide
        return null;
    }

    private int CalculerLaDistanceEntreNode(MatNode a, MatNode b)
    {
        int DistanceX = Mathf.Abs(a.x - b.x);
        int DistanceY = Mathf.Abs(a.y - b.y);
        int restant = Mathf.Abs(DistanceX - DistanceY);
        int total = COUT_MOUVEMENT_DIAGONAL * Mathf.Min(DistanceX, DistanceY) + COUT_MOUVEMENT_DROIT * restant;
        return total;
    }

   

    private MatNode CalculerPlusGrandHcost(List<MatNode> listNode)
    {
      
        MatNode plusGrandHCostNode = listNode[0];
        for (int i = 0; i < listNode.Count; i++)
        {
            if ( listNode[i].Hcost >= plusGrandHCostNode.Hcost)
            {
                plusGrandHCostNode = listNode[i];
              

            }

        }
    
        return plusGrandHCostNode;
    }


    public MatGrid getGrid()
    {
        return grid;
    }
}
