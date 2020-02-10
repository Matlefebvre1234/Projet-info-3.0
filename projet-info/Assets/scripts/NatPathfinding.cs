using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatPathfinding : MonoBehaviour
{
    // Variables public
    public float dimCell = 0.5f;
    //public GameObject backgroundContainer;

    // Variables
    private Vector3 origine = new Vector3(8, 1);
    private List<string> map;
    private Node[,] nodeMap;
    public Grid<Node> grid;

    // Permet de créer la grille de départ 
    // avec toute les valeurs nécéssaires
    public NatPathfinding(int largeur, int hauteur)
    {
        grid = new Grid<Node>(largeur, hauteur, dimCell, origine, (Grid<Node> g, int x, int y) => new Node(g, x, y));
    }

    // permet d'analyser la map, pour ensuite exécuter
    // l'algorithme A-Star et trouver le chemin
    public List<Node> FindPath(int startX, int startY, int endX, int endY)
    {
        // Analyser la map
        nodeMap = new Node[grid.GetLargueur(), grid.GetHauteur()];
        Debug.Log("Node start: " + grid.GetGridObject(startX, startY));
        Node start = grid.GetGridObject(startX, startY);
        Debug.Log("Node end: " + grid.GetGridObject(endX, endY));
        Node goal = grid.GetGridObject(endX, endY);
        //Node start = null;
        //Node goal = null;

        for (int x = 0; x < grid.GetLargueur(); x++)
        {
            for (int y = 0; y < grid.GetHauteur(); y++)
            {
                Node node = grid.GetGridObject(x, y);
                node.Gcost = int.MaxValue;
                node.cameFromNode = null;
            }
        }
        /*
        for (int y = 0; y < grid.GetLargueur(); y++)
        {
            Transform backgroundRow = backgroundContainer.transform.GetChild(y);

            for (int x = 0; x < grid.GetHauteur(); x++)
            {
                Node tile = backgroundRow.GetChild(x).GetComponent<Node>();

                Node node = grid.GetGridObject(x, y);

                node.cameFromNode = tile;

                nodeMap[x, y] = node;
            }
        }
        */

        // Executer l'algorithme A-Star.
        List<Node> nodePath = ExecuteAStar(start, goal);
        nodePath.Reverse();

        return nodePath;
    }

    // Permet de savoir sur quelle node le joueur
    // est et de connaitre les informations nécéssaires
    // sur la tuile ou le joueur se tient
    
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
    


    // Permet d'exécuter l'algorithme principale,
    // qui sert à trouver le chemin le plus cours
    // pour attendre le point visé
    private List<Node> ExecuteAStar(Node start, Node goal)
    {
        // Cette list sert à évaluer le potentiel de chaque nodes
        // pour faire le meilleur chemin et qui devrait être
        // visitée. On commence toujours à l'origine.
        List<Node> openList = new List<Node>() { start };

        // Cette liste permet de se souvenir des nodes visitées
        List<Node> closedList = new List<Node>();

        // Permet d'initialiser la node initiale
        // f = g +h
        start.Gcost = 0;
        start.Fcost = CalculerHCost(start, goal);


        // l'algorithme principale
        while (openList.Count > 0)
        {
            // On regarde au début la node qui à le
            // coût estimé le plus bas pour rejoindre
            // l'objectif
            Node current = openList[0];
            foreach (Node node in openList)
            {
                if (node.Fcost < current.Fcost)
                {
                    current = node;
                }
            }

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
            List<Node> neighbours = GetNeighnourNodes(current);
            foreach (Node neighbour in neighbours)
            {
                if (closedList.Contains(neighbour))
                {
                    // Si la node voisine à été visité, 
                    // on l'ignore
                    continue;
                }

                if (!openList.Contains(neighbour))
                {
                    // Si la node n'a pas été visité, 
                    // on peut la considéré comme valide et
                    // la rajouté dans la liste
                    openList.Add(neighbour);
                }

                // On calcule une nouvelle valeur pour g et on vérifie
                // si elle est meilleur que la précédente.
                int candidateG = current.Gcost + 1;
                if (candidateG >= neighbour.Gcost)
                {
                    // Si la valeur de g calculé est plus grande ou égale à la précédente,
                    // on ne la considére pas, car elle est moins bonne ( il y a
                    // un meilleur chemin calculé)
                    continue;
                }
                else
                {
                    // Sinon, cela veux dire que l'on a trouvé un meilleur chemin 
                    // On initialise les nouvelles valeurs
                    neighbour.cameFromNode = current;
                    neighbour.Gcost = candidateG;
                    neighbour.Fcost = neighbour.Gcost + CalculerHCost(neighbour, goal);
                }
            }
        }

        //Il n'y a pas de chemin
        return new List<Node>();
    }


    // Permet d'aller cherhcher toute les nodes 
    // voisines à celle sur laquel on est et
    // vérifier si on peut y accéder
    private List<Node> GetNeighnourNodes(Node node)
    {
        List<Node> neighbours = new List<Node>();

        // Vérification de la gauche (Ouest)
        if (node.x - 1 >= 0)
        {
            // Ouest
            neighbours.Add(nodeMap[node.x - 1, node.y]);

            if (node.y - 1 >= 0)
            {
                // Sud-Ouest
                neighbours.Add(nodeMap[node.x - 1, node.y - 1]);
            }

            if (node.y + 1 < grid.GetHauteur())
            {
                // Nord-Ouest
                neighbours.Add(nodeMap[node.x - 1, node.y + 1]);
            }
        }

        // Vérification de la droite (Est)
        if (node.x + 1 <= grid.GetLargueur() - 1)
        {
            // Est
           neighbours.Add(nodeMap[node.x + 1, node.y]);

            //Sud-Est
            if(node.y - 1 >= 0)
            {
                neighbours.Add(nodeMap[node.x - 1, node.y - 1]);
            }

            // Nord-Est
            if(node.y +1 < grid.GetHauteur())
            {
                neighbours.Add(nodeMap[node.x + 1, node.y + 1]);
            }
        }

        // Vérification du bas (Sud)
        if (node.x - 1 >= 0)
        {
            // Sud
          neighbours.Add(nodeMap[node.x, node.y - 1]);
        }

        // Vérification du haut (Nord)
        if (node.y <= grid.GetHauteur())
        {
            // Nord
           neighbours.Add(nodeMap[node.x, node.y + 1]);
        }

        return neighbours;
    }


    // Une fois que les nodes sont populés, il
    // faut lire chaque node précédente et 
    // et construire le chemin
    private List<Node> BuilPath(Node node)
    {
        List<Node> path = new List<Node>() { node };
        
        while (node.cameFromNode != null)
        {
            node = node.cameFromNode;
            path.Add(node);
        }

        return path;
    }

    // Sert à calculer la distance entre deux nodes et la valeur du h cost
    private int CalculerHCost(Node node1, Node node2)
    {
        return Mathf.Abs(node1.x - node2.x) + Mathf.Abs(node1.y - node2.y);
    }

    public Grid<Node> getGrid()
    {
        return grid;
    }
}
