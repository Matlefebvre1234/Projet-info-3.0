using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingMathias
{
    private const int MOUVEMENT_SUR_AXE = 10;
    private const int MOUVEMENT_DIAGONAL = 14;
    private GridMathias grille;
    private List<CheminMathias> listeOuverte;
    private List<CheminMathias> listeFermee;
    private Vector3 Origine = new Vector3(8, 1);

    public static PathfindingMathias Instance { get; private set; }

    //Constructeur
    public PathfindingMathias()
    {
        Instance = this;
        grille = GameObject.FindObjectOfType<GridMonstresMathias>().getGrid();
    }

    //Méthode qui créer le chemin optimal à suivre à l'aide de l'algorithme A*
    public List<CheminMathias> Chemin(int debutX, int debutY, int finX, int finY)
    {
        CheminMathias caseDebut = grille.GetGridObject(debutX, debutY);
        CheminMathias caseFin = grille.GetGridObject(finX, finY);

        listeOuverte = new List<CheminMathias>() { caseDebut };
        listeFermee = new List<CheminMathias>();

        //Création de toutes les cases présentes dans la grille, on donne une valeur maximum à valeurG afin qu'aucune case ne soit viable pour le chemin
        for (int x = 0; x < grille.GetLargueur(); x++)
        {
            for (int y = 0; y < grille.GetHauteur(); y++)
            {
                CheminMathias casesGrille = grille.GetGridObject(x, y);
                casesGrille.valeurG = int.MaxValue;
                casesGrille.CalculerF();
                casesGrille.casePrecedente = null;
            }
        }

        //On donne une valeur de 0 à la valeurG de la case de départ, car l'ennemi est déjà sur cette case
        caseDebut.valeurG = 0;
        caseDebut.valeurH = CalculerH(caseDebut, caseFin);
        caseDebut.CalculerF();

        //On cherche la case qui a la valeurF la plus basse dans la listeOuverte afin de trouver la prochaine case du chemin
        while (listeOuverte.Count > 0)
        {
            CheminMathias caseActuelle = FPlusBas(listeOuverte);

            //Si la case avec la valeurF la plus basse est la dernière, on calcule le chemin avec toutes les cases trouvées
            if (caseActuelle == caseFin)
            {
                return CalculerChemin(caseFin);
            }

            //Dès qu'une case est analysée, on la retire des cases à considérer
            listeOuverte.Remove(caseActuelle);
            listeFermee.Add(caseActuelle);

            //On cherche les cases voisines à la case trouvée, afin de trouver la prochaine case du chemin
            foreach (CheminMathias caseVoisine in GetListeVoisins(caseActuelle))
            {
                if (listeFermee.Contains(caseVoisine))
                {
                    continue;
                }

                int gTemp = caseActuelle.valeurG + CalculerH(caseActuelle, caseVoisine);

                if (gTemp < caseVoisine.valeurG)
                {
                    caseVoisine.casePrecedente = caseActuelle;
                    caseVoisine.valeurG = gTemp;
                    caseVoisine.valeurH = CalculerH(caseVoisine, caseFin);
                    caseVoisine.CalculerF();

                    if (!listeOuverte.Contains(caseVoisine))
                    {
                        listeOuverte.Add(caseVoisine);
                    }
                }
            }
        }

        return null;
    }

    //Vérification des cases autour de la case sélectionnée
    private List<CheminMathias> GetListeVoisins(CheminMathias caseActuelle)
    {

        List<CheminMathias> listeVoisins = new List<CheminMathias>();

        if (caseActuelle.positionX - 1 >= 0 && grille.GetGridObject(caseActuelle.positionX - 1, caseActuelle.positionY).GetObstacle() == false)
        {
            //Gauche
            listeVoisins.Add(grille.GetGridObject(caseActuelle.positionX - 1, caseActuelle.positionY));

            if (caseActuelle.positionY - 1 >= 0 && grille.GetGridObject(caseActuelle.positionX - 1, caseActuelle.positionY - 1).GetObstacle() == false)
            {
                listeVoisins.Add(grille.GetGridObject(caseActuelle.positionX - 1, caseActuelle.positionY - 1));
            }

            if (caseActuelle.positionY + 1 < grille.GetHauteur() && grille.GetGridObject(caseActuelle.positionX - 1, caseActuelle.positionY + 1).GetObstacle() == false)
            {
                listeVoisins.Add(grille.GetGridObject(caseActuelle.positionX - 1, caseActuelle.positionY + 1));
            }

        }
        if (caseActuelle.positionX + 1 < grille.GetLargueur() && grille.GetGridObject(caseActuelle.positionX + 1, caseActuelle.positionY).GetObstacle() == false)
        {
            // Droite
            listeVoisins.Add(grille.GetGridObject(caseActuelle.positionX + 1, caseActuelle.positionY));

            if (caseActuelle.positionY - 1 >= 0 && grille.GetGridObject(caseActuelle.positionX + 1, caseActuelle.positionY - 1).GetObstacle() == false)
            {
                listeVoisins.Add(grille.GetGridObject(caseActuelle.positionX + 1, caseActuelle.positionY - 1));
            }

            if (caseActuelle.positionY + 1 < grille.GetHauteur() && grille.GetGridObject(caseActuelle.positionX + 1, caseActuelle.positionY + 1).GetObstacle() == false)
            {
                listeVoisins.Add(grille.GetGridObject(caseActuelle.positionX + 1, caseActuelle.positionY + 1));
            }

        }
        // Haut
        if (caseActuelle.positionY - 1 >= 0 && grille.GetGridObject(caseActuelle.positionX, caseActuelle.positionY - 1).GetObstacle() == false)
        {
            listeVoisins.Add(grille.GetGridObject(caseActuelle.positionX, caseActuelle.positionY - 1));
        }

        // Bas
        if (caseActuelle.positionY + 1 < grille.GetHauteur() && grille.GetGridObject(caseActuelle.positionX, caseActuelle.positionY + 1).GetObstacle() == false)
        {
            listeVoisins.Add(grille.GetGridObject(caseActuelle.positionX, caseActuelle.positionY + 1));
        }

        return listeVoisins;
    }

    public CheminMathias GetCase(int x, int y)
    {
        return grille.GetGridObject(x, y);
    }

    private List<CheminMathias> CalculerChemin(CheminMathias caseFin)
    {
        List<CheminMathias> chemin = new List<CheminMathias>();
        chemin.Add(caseFin);
        CheminMathias temp = caseFin;

        while (temp.casePrecedente != null)
        {
            chemin.Add(temp.casePrecedente);
            temp = temp.casePrecedente;
        }

        chemin.Reverse();

        return chemin;

    }

    private int CalculerH(CheminMathias pt1, CheminMathias pt2)
    {

        int d_x = Mathf.Abs(pt1.positionX - pt2.positionX);
        int d_y = Mathf.Abs(pt1.positionY - pt2.positionY);
        int reste = Mathf.Abs(d_x - d_y);
        int coutFinal = MOUVEMENT_DIAGONAL * Mathf.Min(d_x, d_y) + MOUVEMENT_SUR_AXE * reste;

        return coutFinal;
    }

    private CheminMathias FPlusBas(List<CheminMathias> listeChemin)
    {
        CheminMathias fBas = listeChemin[0];

        for(int i = 0; i < listeChemin.Count; i++)
        {

            if (listeChemin[i].valeurF < fBas.valeurF)
            {
                fBas = listeChemin[i];
            }
        }

        return fBas;
    }

    public List<Vector3> TrouverChemin(Vector3 debut, Vector3 fin)
    {
        int debutX;
        int debutY;

        int finX;
        int finY;

        grille.GetXY(debut, out debutX, out debutY);
        grille.GetXY(fin, out finX, out finY);

        List<CheminMathias> chemin = Chemin(debutX, debutY, finX, finY);

        if(chemin == null)
        {
            return null;
        }

        else
        {
            List<Vector3> cheminVectors = new List<Vector3>();

            foreach (CheminMathias pathnode in chemin)
            {
                Vector3 ajout = new Vector3(pathnode.positionX, pathnode.positionY);
                Vector3 ajout2 = new Vector3(4, 0.5f);
                cheminVectors.Add(ajout * grille.GetDimCell() + Vector3.one * 0.25f + ajout2);
            }

            return cheminVectors;
        }
    }

    //Getter qui retourne la grille utilisée
    public GridMathias GetGrid()
    {
        return grille;
    }
}
