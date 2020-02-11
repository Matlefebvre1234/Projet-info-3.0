using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatPathfinding : MonoBehaviour
{
    // Variables public
    public float dimCell = 0.5f;
    public NatGrid grid;
    //public GameObject backgroundContainer;

    // Variables
    private Vector3 origine = new Vector3(8, 1);
    private List<string> map;
    //private Node[,] nodeMap;
    private const int COUT_MOUVEMENT_DROIT = 10;
    private const int COUT_MOUVEMENT_DIAGONAL = 14;

    // Permet de créer la grille de départ 
    // avec toute les valeurs nécéssaires
    public NatPathfinding(int largeur, int hauteur)
    {
        grid = new NatGrid(largeur, hauteur, dimCell, origine);
    }

    // permet d'analyser la map, pour ensuite exécuter
    // l'algorithme A-Star et trouver le chemin
    public List<NatNode> FindPath(int startX, int startY, int endX, int endY)
    {
        // Analyser la map
        //nodeMap = new Node[grid.GetLargueur(), grid.GetHauteur()];
        NatNode start = grid.GetGridObject(startX, startY);
        NatNode goal = grid.GetGridObject(endX, endY);

        for (int x = 0; x < grid.GetLargueur(); x++)
        {
            for (int y = 0; y < grid.GetHauteur(); y++)
            {
                NatNode node = grid.GetGridObject(x, y);
                node.Gcost = int.MaxValue;
                node.cameFromNode = null;
                node.CalculerFcost();
            }
        }

        // Executer l'algorithme A-Star.
        List<NatNode> nodePath = ExecuteAStar(start, goal);
        //nodePath.Reverse();

        return nodePath;
    }

    // Permet de savoir sur quelle node le joueur
    // est et de connaitre les informations nécéssaires
    // sur la tuile ou le joueur se tient
    /*
    private Node FindNode(GameObject obj)
    {
        Collider2D[] collindingObjects = Physics2D.OverlapCircleAll(obj.transform.position, 0.2f);

        foreach (Collider2D collidingObject in collindingObjects)
        {
            if (collidingObject.gameObject.GetComponent<Node>() != null)
            {
                // Le joueur est sur cette node
                Node tile = collidingObject.gameObject.GetComponent<Node>();

                // Permet de trouver la node qui contient la tuile
                for (int y = 0; y < grid.GetHauteur(); y++)
                {
                    for (int x = 0; x < grid.GetLargueur(); x++)
                    {
                        Node node = nodeMap[x, y];

                        if (node.cameFromNode == tile)
                        {
                            return node;
                        }
                    }
                }
            }
        }
        return null;
    }
    */



    // Permet d'exécuter l'algorithme principale,
    // qui sert à trouver le chemin le plus cours
    // pour attendre le point visé
    private List<NatNode> ExecuteAStar(NatNode start, NatNode goal)
    {
        // Cette list sert à évaluer le potentiel de chaque nodes
        // pour faire le meilleur chemin et qui devrait être
        // visitée. On commence toujours à l'origine.
        List<NatNode> openList = new List<NatNode>() { start };

        // Cette liste permet de se souvenir des nodes visitées
        List<NatNode> closedList = new List<NatNode>();

        // Permet d'initialiser la node initiale
        start.Gcost = 0;
        start.Hcost = CalculerLaDistanceEntreNode(start, goal);
        start.CalculerFcost();


        // l'algorithme principale
        while (openList.Count > 0)
        {
            // On regarde au début la node qui à le
            // coût estimé le plus bas pour rejoindre
            // l'objectif
            NatNode current = CalculerLePlusBasF(openList);


            // On regarde si l'objectif est atteint
            if (current == goal)
            {
                return BuilPath(goal);
            }

            // On s'assure que la node visité ne soit 
            // pas visité de nouveau
            openList.Remove(current);
            closedList.Add(current);

            // On éxécute l'algorithme dans la node voisine
            //List<Node> neighbours = GetNeighnourNodes(current);
            foreach (NatNode neighbour in GetNeighnourNodes(current))
            {

                if (closedList.Contains(neighbour))
                {
                    // Si la node voisine à été visité, 
                    // on l'ignore
                    continue;
                }

                if (neighbour.obstacle == true)
                {
                    closedList.Add(neighbour);
                    continue;
                }

                // On calcule une nouvelle valeur pour g et on vérifie
                // si elle est meilleur que la précédente.
                int candidateG = current.Gcost + CalculerLaDistanceEntreNode(current, neighbour);

                //int candidateG = current.Gcost + 1;
                if (candidateG < neighbour.Gcost)
                {
                    // Sinon, cela veux dire que l'on a trouvé un meilleur chemin 
                    // On initialise les nouvelles valeurs
                    neighbour.Gcost = candidateG;
                    neighbour.Hcost = CalculerLaDistanceEntreNode(current, goal);
                    neighbour.cameFromNode = current;
                    neighbour.CalculerFcost();

                    if (!openList.Contains(neighbour))
                    {
                        // Si la node n'a pas été visité, 
                        // on peut la considéré comme valide et
                        // la rajouté dans la liste
                        openList.Add(neighbour);
                    }
                }
            }
        }

        //Il n'y a pas de chemin
        return null;
    }

    private NatNode CalculerLePlusBasF(List<NatNode> node)
    {
        NatNode fPlusBas = node[0];

        for (int i = 0; i < node.Count; i++)
        {
            if (node[i].Fcost < fPlusBas.Fcost)
            {
                fPlusBas = node[i];
            }

        }

        return fPlusBas;
    }

    // Permet d'aller cherhcher toute les nodes 
    // voisines à celle sur laquel on est et
    // vérifier si on peut y accéder
    private List<NatNode> GetNeighnourNodes(NatNode node)
    {
        List<NatNode> neighbours = new List<NatNode>();

        // Vérification de la gauche (Ouest)
        if (node.x - 1 >= 0)
        {
            // Ouest
            neighbours.Add(grid.GetGridObject(node.x - 1, node.y));

            if (node.y - 1 >= 0)
            {
                // Sud-Ouest
                neighbours.Add(grid.GetGridObject(node.x - 1, node.y - 1));
            }

            if (node.y + 1 < grid.GetHauteur())
            {
                // Nord-Ouest
                neighbours.Add(grid.GetGridObject(node.x - 1, node.y + 1));
            }
        }

        // Vérification de la droite (Est)
        if (node.x + 1 < grid.GetLargueur())
        {
            // Est
            neighbours.Add(grid.GetGridObject(node.x + 1, node.y));

            //Sud-Est
            if (node.y - 1 >= 0)
            {
                neighbours.Add(grid.GetGridObject(node.x + 1, node.y - 1));
            }

            // Nord-Est
            if (node.y + 1 < grid.GetHauteur())
            {
                neighbours.Add(grid.GetGridObject(node.x + 1, node.y + 1));
            }
        }

        // Vérification du bas (Sud)
        if (node.y - 1 >= 0)
        {
            // Sud
            neighbours.Add(grid.GetGridObject(node.x, node.y - 1));
        }

        // Vérification du haut (Nord)
        if (node.y + 1 < grid.GetHauteur())
        {
            // Nord
            neighbours.Add(grid.GetGridObject(node.x, node.y + 1));
        }

        return neighbours;
    }


    // Une fois que les nodes sont populés, il
    // faut lire chaque node précédente et 
    // et construire le chemin
    private List<NatNode> BuilPath(NatNode node)
    {
        List<NatNode> path = new List<NatNode>() { node };

        while (node.cameFromNode != null)
        {

            path.Add(node.cameFromNode);
            node = node.cameFromNode;
        }
        path.Reverse();
        return path;
    }

    // Permet de calculer la distance entre deux node pour calculé 
    // sont coût de déplacement d'une node à une autre.
    private int CalculerLaDistanceEntreNode(NatNode nodeA, NatNode nodeB)
    {
        int DistanceX = Mathf.Abs(nodeA.x - nodeB.x);
        int DistanceY = Mathf.Abs(nodeA.y - nodeB.y);
        int restant = Mathf.Abs(DistanceX - DistanceY);
        return COUT_MOUVEMENT_DIAGONAL * Mathf.Min(DistanceX, DistanceY) + COUT_MOUVEMENT_DROIT * restant;
    }

    //Permet de routourner la grid construite
    public NatGrid getGrid()
    {
        return grid;
    }
}
