using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatPathfinding
{
    // Variables public
    public float TileDimension = 0.5f;
    public GrilleNatael grille;

    // Variables
    private Vector3 origine = new Vector3(8, 1);
    private const int ForwardCost = 10;
    private const int DiagonalCost = 14;


    // Permet de créer la grille de départ 
    // avec toute les valeurs nécéssaires
    public NatPathfinding(int largeur, int hauteur)
    {
        grille = new GrilleNatael(largeur, hauteur, TileDimension, origine);
    }

    // permet d'analyser la map, pour ensuite exécuter
    // l'algorithme A-Star et trouver le chemin
    public List<PointsNatael> TrouverLeChemin(int GoblinPositionX, int GoblinPositionY, int GoalTileX, int GoalTileY)
    {
        // Analyser la map
        PointsNatael start = grille.GetGrid(GoblinPositionX, GoblinPositionY);
        PointsNatael goal = grille.GetGrid(GoalTileX, GoalTileY);

        for (int x = 0; x < grille.GetLargueur(); x++)
        {
            for (int y = 0; y < grille.GetHauteur(); y++)
            {
                PointsNatael node = grille.GetGrid(x, y);
                node.Gcost = int.MaxValue;
                node.NodePrecedente = null;
                node.CalculerFcost();
            }
        }

        // Executer l'algorithme A-Star.
        List<PointsNatael> nodePath = AlgorithmeAStar(start, goal);

        return nodePath;
    }

    // Permet d'exécuter l'algorithme principale,
    // qui sert à trouver le chemin le plus cours
    // pour attendre le point visé
    private List<PointsNatael> AlgorithmeAStar(PointsNatael debut, PointsNatael fin)
    {
        // Cette list sert à évaluer le potentiel de chaque nodes
        // pour faire le meilleur chemin et qui devrait être
        // visitée. On commence toujours à l'origine.
        List<PointsNatael> ListePointsPossible = new List<PointsNatael>() { debut };

        // Cette liste permet de se souvenir des nodes visitées
        List<PointsNatael> ListePointsDejaVue = new List<PointsNatael>();

        // Permet d'initialiser la node initiale
        debut.Gcost = 0;
        debut.Hcost = CalculerLaDistanceEntrePoints(debut, fin);
        debut.CalculerFcost();


        // l'algorithme principale
        while (ListePointsPossible.Count > 0)
        {
            // On regarde au début la node qui à le
            // coût estimé le plus bas pour rejoindre
            // l'objectif
            PointsNatael current = CalculerLePlusBasF(ListePointsPossible);


            // On regarde si l'objectif est atteint
            if (current == fin)
            {
                return ConstruireChemin(fin);
            }

            // On s'assure que la node visité ne soit 
            // pas visité de nouveau
            ListePointsPossible.Remove(current);
            ListePointsDejaVue.Add(current);

            // On éxécute l'algorithme dans la node voisine
            //List<Node> neighbours = CaseVoisine(current);
            foreach (PointsNatael neighbour in CaseVoisine(current))
            {

                if (ListePointsDejaVue.Contains(neighbour))
                {
                    // Si la node voisine à été visité, 
                    // on l'ignore
                    continue;
                }

                if (neighbour.obstacle == true)
                {
                    ListePointsDejaVue.Add(neighbour);
                    continue;
                }

                // On calcule une nouvelle valeur pour g et on vérifie
                // si elle est meilleur que la précédente.
                int candidateG = current.Gcost + CalculerLaDistanceEntrePoints(current, neighbour);

                //int candidateG = current.Gcost + 1;
                if (candidateG < neighbour.Gcost)
                {
                    // Sinon, cela veux dire que l'on a trouvé un meilleur chemin 
                    // On initialise les nouvelles valeurs
                    neighbour.Gcost = candidateG;
                    neighbour.Hcost = CalculerLaDistanceEntrePoints(current, fin);
                    neighbour.NodePrecedente = current;
                    neighbour.CalculerFcost();

                    if (!ListePointsPossible.Contains(neighbour))
                    {
                        // Si la node n'a pas été visité, 
                        // on peut la considéré comme valide et
                        // la rajouté dans la liste
                        ListePointsPossible.Add(neighbour);
                    }
                }
            }
        }

        //Il n'y a pas de chemin
        return null;
    }

    private PointsNatael CalculerLePlusBasF(List<PointsNatael> node)
    {
        PointsNatael fPlusBas = node[0];

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
    private List<PointsNatael> CaseVoisine(PointsNatael node)
    {
        List<PointsNatael> neighbours = new List<PointsNatael>();

        // Vérification de la gauche (Ouest)
        if (node.x - 1 >= 0)
        {
            // Ouest
            neighbours.Add(grille.GetGrid(node.x - 1, node.y));

            if (node.y - 1 >= 0)
            {
                // Sud-Ouest
                neighbours.Add(grille.GetGrid(node.x - 1, node.y - 1));
            }

            if (node.y + 1 < grille.GetHauteur())
            {
                // Nord-Ouest
                neighbours.Add(grille.GetGrid(node.x - 1, node.y + 1));
            }
        }

        // Vérification de la droite (Est)
        if (node.x + 1 < grille.GetLargueur())
        {
            // Est
            neighbours.Add(grille.GetGrid(node.x + 1, node.y));

            //Sud-Est
            if (node.y - 1 >= 0)
            {
                neighbours.Add(grille.GetGrid(node.x + 1, node.y - 1));
            }

            // Nord-Est
            if (node.y + 1 < grille.GetHauteur())
            {
                neighbours.Add(grille.GetGrid(node.x + 1, node.y + 1));
            }
        }

        // Vérification du bas (Sud)
        if (node.y - 1 >= 0)
        {
            // Sud
            neighbours.Add(grille.GetGrid(node.x, node.y - 1));
        }

        // Vérification du haut (Nord)
        if (node.y + 1 < grille.GetHauteur())
        {
            // Nord
            neighbours.Add(grille.GetGrid(node.x, node.y + 1));
        }

        return neighbours;
    }


    // Une fois que les nodes sont populés, il
    // faut lire chaque node précédente et 
    // et construire le chemin
    private List<PointsNatael> ConstruireChemin(PointsNatael node)
    {
        List<PointsNatael> path = new List<PointsNatael>() { node };

        while (node.NodePrecedente != null)
        {

            path.Add(node.NodePrecedente);
            node = node.NodePrecedente;
        }
        path.Reverse();
        return path;
    }

    // Permet de calculer la distance entre deux node pour calculé 
    // sont coût de déplacement d'une node à une autre.
    private int CalculerLaDistanceEntrePoints(PointsNatael nodeA, PointsNatael nodeB)
    {
        int DistanceX = Mathf.Abs(nodeA.x - nodeB.x);
        int DistanceY = Mathf.Abs(nodeA.y - nodeB.y);
        int restant = Mathf.Abs(DistanceX - DistanceY);
        return DiagonalCost * Mathf.Min(DistanceX, DistanceY) + ForwardCost * restant;
    }

    //Permet de routourner la grille construite
    public GrilleNatael getGrid()
    {
        return grille;
    }
}
