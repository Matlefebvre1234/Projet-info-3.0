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


    // Permet de créer la grille de départ 
    // avec toute les valeurs nécéssaires
    public NatPathfinding(int largeur, int hauteur)
    {
        grille = new GrilleNatael(largeur, hauteur, dimensionCase, origine);
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
                @case.NodePrecedente = null;
                @case.CalculerFcost();
            }
        }

        // Executer l'algorithme A-Star.
        List<CasesNatael> cheminDeCases = AlgorithmeAEtoile(pointDebut, pointFin);

        // Retourne le chemin de case qui permet
        // d'arrivé au point voulu
        return cheminDeCases;
    }

    // Permet d'exécuter l'algorithme principale,
    // qui sert à trouver le chemin le plus court
    // pour attendre le point visé
    private List<CasesNatael> AlgorithmeAEtoile(CasesNatael debut, CasesNatael fin)
    {
        // Cette list sert à évaluer le potentiel de chaque cases
        // pour faire le meilleur chemin, qui devrait être
        // visitée. On commence toujours à l'origine.
        List<CasesNatael> ListePointsPossible = new List<CasesNatael>() { debut };

        // Cette liste permet de se souvenir des cases visitées
        List<CasesNatael> ListePointsDejaVue = new List<CasesNatael>();

        // Permet d'initialiser la case initiale
        debut.Gcost = 0;
        debut.Hcost = CalculerLaDistanceEntrePoints(debut, fin);
        debut.CalculerFcost();


        // l'algorithme principale
        while (ListePointsPossible.Count > 0)
        {
            // On regarde au début la case qui à le
            // coût estimé le plus bas pour rejoindre
            // l'objectif
            CasesNatael current = CalculerLePlusBasF(ListePointsPossible);


            // On regarde si l'objectif est atteint
            if (current == fin)
            {
                return ConstruireChemin(fin);
            }

            // On s'assure que la case visité ne soit 
            // pas visité de nouveau
            ListePointsPossible.Remove(current);
            ListePointsDejaVue.Add(current);

            // On éxécute l'algorithme dans la case voisine
            foreach (CasesNatael casesVoisine in CaseVoisine(current))
            {

                if (ListePointsDejaVue.Contains(casesVoisine))
                {
                    // Si la case voisine à été visité, 
                    // on l'ignore
                    continue;
                }

                if (casesVoisine.obstacle == true)
                {
                    ListePointsDejaVue.Add(casesVoisine);
                    continue;
                }

                // On calcule une nouvelle valeur pour g et on vérifie
                // si elle est meilleur que la précédente.
                int candidatG = current.Gcost + CalculerLaDistanceEntrePoints(current, casesVoisine);

                if (candidatG < casesVoisine.Gcost)
                {
                    // Sinon, cela veux dire que l'on a trouvé un meilleur chemin 
                    // On initialise les nouvelles valeurs
                    casesVoisine.Gcost = candidatG;
                    casesVoisine.Hcost = CalculerLaDistanceEntrePoints(current, fin);
                    casesVoisine.NodePrecedente = current;
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

    // Permet de trouver le coût le plus bas calculé 
    // autour de la case qui est vérifié
    private CasesNatael CalculerLePlusBasF(List<CasesNatael> node)
    {
        CasesNatael fPlusBas = node[0];

        for (int i = 0; i < node.Count; i++)
        {
            if (node[i].Fcost < fPlusBas.Fcost)
            {
                fPlusBas = node[i];
            }

        }

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

        while (@case.NodePrecedente != null)
        {
            chemin.Add(@case.NodePrecedente);
            @case = @case.NodePrecedente;
        }

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
