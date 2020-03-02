using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matPathfinding 
{
    private const int COUT_MOUVEMENT_DROIT = 10;
    private const int COUT_MOUVEMENT_DIAGONAL = 14;


    public float dimCell = 0.5f;
    private Vector3 origine = new Vector3(8, 1);
    private MatGrid grid;
    private List<MatNode> openList;
    private List<MatNode> closeList;
    private int n_largeur = 22;
    private int n_hauteur = 14;
    


    public matPathfinding()
    {

        grid = new MatGrid(n_largeur, n_hauteur, dimCell, origine);

    }

    public List<MatNode> FindPath(int startX,int startY,int endX,int endY)
    {
        MatNode startNode = grid.GetGridObject(startX, startY);
        MatNode endNode = grid.GetGridObject(endX, endY);

        openList = new List<MatNode> { startNode };
        closeList = new List<MatNode>();

        for(int x =0;x < grid.GetLargueur();x++)
        {
            for(int y =0;y<grid.GetHauteur(); y++)
            {
                MatNode node = grid.GetGridObject(x, y);
                node.Gcost = int.MaxValue;
                node.cameFromNode = null;
                node.CalculerFcost();

            }

        }
        startNode.Gcost = 0;
        startNode.Hcost = CalculerLaDistanceEntreNode(startNode, endNode);
        startNode.CalculerFcost();

        while (openList.Count > 0)
        {
            //Debug.Log(openList.Count);

            MatNode NodeActuelle = CalculerLowerFcost(openList);

            //Debug.Log(NodeActuelle.x + ", " + NodeActuelle.y);

            if (NodeActuelle == endNode) return CalculerPathNode(endNode); //fin de la recherche

          
            
                openList.Remove(NodeActuelle);
                closeList.Add(NodeActuelle);

            foreach (MatNode nodeVoisine in GetNodeVoisin(NodeActuelle))
            {

                

                if (closeList.Contains(nodeVoisine)) continue;
                if(nodeVoisine.obstacle == true)
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


    private List<MatNode> GetNodeVoisin(MatNode nodeActuelle)
    {
        List<MatNode> neighbourList = new List<MatNode>();
        if (nodeActuelle.x - 1 >= 0)
        {
            // Left
            neighbourList.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y));
            // Left Down
            if (nodeActuelle.y - 1 >= 0) neighbourList.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y - 1));
            // Left Up
            if (nodeActuelle.y + 1 < grid.GetHauteur()) neighbourList.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y + 1));
        }
        if (nodeActuelle.x + 1 < grid.GetLargueur())
        {
            // Right
            neighbourList.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y));
            // Right Down
            if (nodeActuelle.y - 1 >= 0) neighbourList.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y - 1));
            // Right Up
            if (nodeActuelle.y + 1 < grid.GetHauteur()) neighbourList.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y + 1));
        }
        // Down
        if (nodeActuelle.y - 1 >= 0) neighbourList.Add(grid.GetGridObject(nodeActuelle.x, nodeActuelle.y - 1));
        // Up
        if (nodeActuelle.y + 1 < grid.GetHauteur()) neighbourList.Add(grid.GetGridObject(nodeActuelle.x, nodeActuelle.y + 1));

        return neighbourList;


    }

    public List<MatNode> CalculerPathNode(MatNode endNode)
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

    private int CalculerLaDistanceEntreNode(MatNode a, MatNode b)
    {
        int DistanceX = Mathf.Abs(a.x - b.x);
        int DistanceY = Mathf.Abs(a.y - b.y);
        int restant = Mathf.Abs(DistanceX - DistanceY);
        return COUT_MOUVEMENT_DIAGONAL * Mathf.Min(DistanceX, DistanceY) + COUT_MOUVEMENT_DROIT * restant;
    }

    private MatNode CalculerLowerFcost(List<MatNode> listNode)
    {
        MatNode lowerFCostNode = listNode[0];
        //Debug.Log(lowerFCostNode.Fcost);

        for (int i = 0; i < listNode.Count; i++)
        {
            if (listNode[i].Fcost < lowerFCostNode.Fcost)
            {
                //Debug.Log(listNode[i].Fcost);
                //Debug.Log(lowerFCostNode.Fcost);
                lowerFCostNode = listNode[i];
            }
        
        }

        //Debug.Log(lowerFCostNode.x + ", " + lowerFCostNode.y);

        return lowerFCostNode;
    }


    public MatGrid getGrid()
    {
        return grid;
    }
}
