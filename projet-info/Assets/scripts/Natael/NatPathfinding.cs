using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatPathfinding
{
    // Variables public
    public float dimensionCase = 0.5f;
    public GrilleNatael grille;

    // Variables
    private Vector3 origine = new Vector3(8, 1);

    //Coût du déplacement
    private const int coutLigneDroite = 10;
    private const int coutDiagonale = 14;

    // Il est le coût de déplacement d'une case à une autre
    // soit en diagonale, à la verticale ou à l'horizontale
    /*public int Gcost;*/

    // Il est le coût total pour un déplacement entre deux cases
    // puisqu'il comprend le coût G + H
    /*public int Fcost;*/

    // Il est la valeur qui estime grossièrement le coût 
    // pour se rendre au point final (valeur Heuristique).
    // Donc, il calcule le coût comme s'il n'y avait pas d'obstacles
    /*public int Hcost;*/


    // Permet de créer la grille de départ 
    // avec toute les valeurs nécéssaires
    public NatPathfinding(int largeur, int hauteur)
    {
        grille = GameObject.FindObjectOfType<GrilleDynamique>().getGrid();
        //grille = new GrilleNatael(largeur, hauteur, dimensionCase, origine);
    }


    // permet d'analyser la map, pour ensuite exécuter
    // l'algorithme A-Star et trouver le chemin
    public List<CasesNatael> TrouverLeChemin(int positionDebutX, int positionDebutY, int positionFinX, int positionFinY)
    {
        // Analyser la map
        // Permet de trouver le point de départ et d'arrivé 
        // dans un contexte donné
        CasesNatael pointDebut = grille.GetGrid(positionDebutX, positionDebutY);
        CasesNatael pointFin = grille.GetGrid(positionFinX, positionFinY);

        for (int x = 0; x < grille.GetLargueur(); x++)
        {
            for (int y = 0; y < grille.GetHauteur(); y++)
            {
                CasesNatael @case = grille.GetGrid(x, y);

                @case.Gcost = int.MaxValue;
                @case.casePrecedente = null;
                @case.CalculerFcost();
            }
        }

        // Executer l'algorithme A-Star.
        List<CasesNatael> cheminDeCases = AlgorithmeAEtoile(pointDebut, pointFin);

        // Retourne le chemin de case qui permet
        // d'arrivé au point voulu
        return cheminDeCases;
    }

    // Permet d'exécuter l'algorithme principal,
    // qui sert à trouver le chemin le plus court
    // pour attendre le point visé
    private List<CasesNatael> AlgorithmeAEtoile(CasesNatael debut, CasesNatael fin)
    {
        // Cette list sert à évaluer le potentiel de chaque cases
        // pour faire le meilleur chemin, qui devrait être
        // visitée. On commence toujours à l'origine (liste ouverte)
        List<CasesNatael> ListePointsPossible = new List<CasesNatael>() { debut };

        // Cette liste permet de se souvenir des cases visitées
        // (liste fermé)
        List<CasesNatael> ListePointsDejaVue = new List<CasesNatael>();

        // Permet d'initialiser la case initiale
        debut.Gcost = 0;
        debut.Hcost = CalculerLaDistanceEntrePoints(debut, fin);
        debut.CalculerFcost();


        // l'algorithme principale
        while (ListePointsPossible.Count > 0)
        {
            // On regarde toutes les cases qui sont contenue dans la liste ouverte
            // et on garde seulement celle qui à la plus petite valeur
            CasesNatael caseCoutPlusBas = CalculerLePlusBasF(ListePointsPossible);


            // On regarde si l'objectif est atteint
            if (caseCoutPlusBas == fin)
            {
                return ConstruireChemin(fin);
            }

            // On s'assure que la case visité ne soit 
            // pas visité de nouveau
            ListePointsPossible.Remove(caseCoutPlusBas);
            ListePointsDejaVue.Add(caseCoutPlusBas);

            // On éxécute l'algorithme dans les cases voisines
            foreach (CasesNatael casesVoisine in CaseVoisine(caseCoutPlusBas))
            {
                if (ListePointsDejaVue.Contains(casesVoisine))
                {
                    // Si la case voisine à déjà été visité, 
                    // on l'ignore
                    continue;
                }

                // Permet de vérifier si la case voisine est un obstacle
                // et si c'est le cas, la rajouter dans la liste fermée
                if (casesVoisine.GetObstacle() == true)
                {
                    ListePointsDejaVue.Add(casesVoisine);
                    continue;
                }

                // On calcule une nouvelle valeur pour G et on vérifie
                // si elle est meilleur que la précédente.
                int candidatG = caseCoutPlusBas.Gcost + CalculerLaDistanceEntrePoints(caseCoutPlusBas, casesVoisine);

                if (candidatG < casesVoisine.Gcost)
                {
                    // Si on rentre ici, cela veux dire que l'on a trouvé un meilleur chemin 
                    // donc on initialise la case avec les nouvelles valeurs
                    casesVoisine.Gcost = candidatG;
                    casesVoisine.Hcost = CalculerLaDistanceEntrePoints(caseCoutPlusBas, fin);
                    casesVoisine.casePrecedente = caseCoutPlusBas;
                    casesVoisine.CalculerFcost();

                    if (!ListePointsPossible.Contains(casesVoisine))
                    {
                        // Si la case n'a pas été visité, 
                        // on peut la considéré comme valide et
                        // la rajouter dans la liste
                        ListePointsPossible.Add(casesVoisine);
                    }
                }
            }
        }

        //Il n'y a pas de chemin
        return null;
    }

    // Permet de trouver le coût total le plus bas calculé 
    // autour de la case qui est vérifiée
    private CasesNatael CalculerLePlusBasF(List<CasesNatael> node)
    {
        CasesNatael fPlusBas = node[0];

        // Permet de vérifier tous les coûts autour de la case vérifié
        // et de ne garder que celui qui est le plus bas
        for (int i = 0; i < node.Count; i++)
        {
            if (node[i].Fcost < fPlusBas.Fcost)
            {
                fPlusBas = node[i];
            }

        }

        // Retourne le coût total le plus bas trouvé
        return fPlusBas;
    }

    // Permet d'aller chercher toute les cases 
    // voisines à celle sur laquel on est et
    // vérifier si on peut y accéder
    private List<CasesNatael> CaseVoisine(CasesNatael node)
    {
        List<CasesNatael> casesVoisines = new List<CasesNatael>();

        // Vérification de la gauche (Ouest)
        if (node.x - 1 >= 0)
        {
            // Ouest
            casesVoisines.Add(grille.GetGrid(node.x - 1, node.y));

            if (node.y - 1 >= 0)
            {
                // Sud-Ouest
                casesVoisines.Add(grille.GetGrid(node.x - 1, node.y - 1));
            }

            if (node.y + 1 < grille.GetHauteur())
            {
                // Nord-Ouest
                casesVoisines.Add(grille.GetGrid(node.x - 1, node.y + 1));
            }
        }

        // Vérification de la droite (Est)
        if (node.x + 1 < grille.GetLargueur())
        {
            // Est
            casesVoisines.Add(grille.GetGrid(node.x + 1, node.y));

            //Sud-Est
            if (node.y - 1 >= 0)
            {
                casesVoisines.Add(grille.GetGrid(node.x + 1, node.y - 1));
            }

            // Nord-Est
            if (node.y + 1 < grille.GetHauteur())
            {
                casesVoisines.Add(grille.GetGrid(node.x + 1, node.y + 1));
            }
        }

        // Vérification du bas (Sud)
        if (node.y - 1 >= 0)
        {
            // Sud
            casesVoisines.Add(grille.GetGrid(node.x, node.y - 1));
        }

        // Vérification du haut (Nord)
        if (node.y + 1 < grille.GetHauteur())
        {
            // Nord
            casesVoisines.Add(grille.GetGrid(node.x, node.y + 1));
        }

        return casesVoisines;
    }


    // Une fois que les nodes sont populés, il
    // faut lire chaque case précédente et 
    // et construire le chemin
    private List<CasesNatael> ConstruireChemin(CasesNatael @case)
    {
        List<CasesNatael> chemin = new List<CasesNatael>() { @case };

        while (@case.casePrecedente != null)
        {
            chemin.Add(@case.casePrecedente);
            @case = @case.casePrecedente;
        }

        // Il faut inversé le chemin trouvé, car 
        // on est partie de la fin au lieu du début 
        chemin.Reverse();

        return chemin;
    }

    // Permet de calculer la distance entre deux case pour calculer
    // sont coût de déplacement d'une case à une autre.
    private int CalculerLaDistanceEntrePoints(CasesNatael nodeA, CasesNatael nodeB)
    {
        int DistanceX = Mathf.Abs(nodeA.x - nodeB.x);
        int DistanceY = Mathf.Abs(nodeA.y - nodeB.y);
        int restant = Mathf.Abs(DistanceX - DistanceY);

        return coutDiagonale * Mathf.Min(DistanceX, DistanceY) + coutLigneDroite * restant;
    }

    //Permet de routourner la grille construite
    public GrilleNatael getGrid()
    {
        return grille;
    }
}
