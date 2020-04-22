using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matPathfinding 
{
    private const int COUT_MOUVEMENT_DROIT = 10;
    private const int COUT_MOUVEMENT_DIAGONAL = 14;

    //Initialisation des variable
    public float dimCell = 0.5f;  //Dimension de chaque case de la grille
    private Vector3 origine = new Vector3(8, 1); //décalage par rapport à l'origine
    private MatGrid grid; //grille de noeuds
    private List<MatNode> openList;
    private List<MatNode> closeList;


    //constructeur
    public matPathfinding()
    {

        grid = GameObject.FindObjectOfType<GrilleMonstresMat>().getGrid();

    }

    //Trouve le chemin le plus court entre un noeud de départ et le noeuds d'arrivé
    public List<MatNode> FindPath(int startX,int startY,int endX,int endY)
    {
        MatNode startNode = grid.GetGridObject(startX, startY); //noeud de départ
        MatNode endNode = grid.GetGridObject(endX, endY); // noeud d'Arrivé

        openList = new List<MatNode> { startNode };
        closeList = new List<MatNode>();

        //Initialisation de tous les noeuds
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

        //Algorithme 
        while (openList.Count > 0)
        {
            MatNode NodeActuelle = CalculerLowerFcost(openList); // Noeud avec le plus petit F de l'openList

            if (NodeActuelle == endNode) return CalculerPathNode(endNode); //fin de la recherche 

                openList.Remove(NodeActuelle);
                closeList.Add(NodeActuelle);

            //Pour chaque noeud autour du noeud actuelle
            foreach (MatNode nodeVoisine in GetNodeVoisin(NodeActuelle))
            {
                //Vérifie si le noeud voisin est dans la close list ou un obstacle
                if (closeList.Contains(nodeVoisine)) continue;
                if(nodeVoisine.obstacle == true)
                {
                    closeList.Add(nodeVoisine);
                    continue;
                }

                //Recalculer les Variables F ,G ,H pour chaque noeud voisin 
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

    //Obtenir tous les noeuds autour du noeud actuelle
    private List<MatNode> GetNodeVoisin(MatNode nodeActuelle)
    {
        List<MatNode> neighbourList = new List<MatNode>();
        if (nodeActuelle.x - 1 >= 0)
        {
            // gauche
            neighbourList.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y));
            // gauche en bas
            if (nodeActuelle.y - 1 >= 0) neighbourList.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y - 1));
            // gauche en haut
            if (nodeActuelle.y + 1 < grid.GetHauteur()) neighbourList.Add(grid.GetGridObject(nodeActuelle.x - 1, nodeActuelle.y + 1));
        }
        if (nodeActuelle.x + 1 < grid.GetLargueur())
        {
            // droite
            neighbourList.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y));
            // droite bas
            if (nodeActuelle.y - 1 >= 0) neighbourList.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y - 1));
            // droite haut
            if (nodeActuelle.y + 1 < grid.GetHauteur()) neighbourList.Add(grid.GetGridObject(nodeActuelle.x + 1, nodeActuelle.y + 1));
        }
        // bas
        if (nodeActuelle.y - 1 >= 0) neighbourList.Add(grid.GetGridObject(nodeActuelle.x, nodeActuelle.y - 1));
        // haut
        if (nodeActuelle.y + 1 < grid.GetHauteur()) neighbourList.Add(grid.GetGridObject(nodeActuelle.x, nodeActuelle.y + 1));

        return neighbourList;


    }

    //Retourne le chemin le plus court
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

    //Calcul la distance entre les noeuds (H)
    private int CalculerLaDistanceEntreNode(MatNode a, MatNode b)
    {
        int DistanceX = Mathf.Abs(a.x - b.x);
        int DistanceY = Mathf.Abs(a.y - b.y);
        int restant = Mathf.Abs(DistanceX - DistanceY);
        return COUT_MOUVEMENT_DIAGONAL * Mathf.Min(DistanceX, DistanceY) + COUT_MOUVEMENT_DROIT * restant;
    }
    
    //retourne le noeud de l'openlist avec le plus petit F
    private MatNode CalculerLowerFcost(List<MatNode> listNode)
    {
        MatNode lowerFCostNode = listNode[0];

        for (int i = 0; i < listNode.Count; i++)
        {
            if (listNode[i].Fcost < lowerFCostNode.Fcost)
            {
                lowerFCostNode = listNode[i];
            }
        
        }

        return lowerFCostNode;
    }


    public MatGrid getGrid()
    {
        return grid;
    }
}
