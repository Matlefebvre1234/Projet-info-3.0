using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEtoileMathias
{
    private const int MOUVEMENT_SUR_AXE = 10;
    private const int MOUVEMENT_DIAGONAL = 14;
    private GridMathias grille;
    private List<Case> listeOuverte;
    private List<Case> listeFermee;
    private Vector3 origine = new Vector3(8, 1);

    public static AEtoileMathias Instance { get; private set; }

    //Constructeur
    public AEtoileMathias()
    {
        Instance = this;
        grille = GameObject.FindObjectOfType<GridMonstresMathias>().getGrid();
    }

    //Méthode qui créer le chemin optimal à suivre à l'aide de l'algorithme A*
    public List<Case> Chemin(int debutX, int debutY, int finX, int finY)
    {
        Case caseDebut = grille.GetGridObject(debutX, debutY);
        Case caseFin = grille.GetGridObject(finX, finY);

        listeOuverte = new List<Case>() { caseDebut };
        listeFermee = new List<Case>();

        //Création de toutes les cases présentes dans la grille, on donne une valeur maximum à valeurG afin qu'aucune case ne soit viable pour le chemin
        for (int x = 0; x < grille.GetLargueur(); x++)
        {
            for (int y = 0; y < grille.GetHauteur(); y++)
            {
                Case casesGrille = grille.GetGridObject(x, y);
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
            Case caseActuelle = FPlusBas(listeOuverte);

            //Si la case avec la valeurF la plus basse est la dernière, on calcule le chemin avec toutes les cases trouvées
            if (caseActuelle == caseFin)
            {
                return CalculerChemin(caseFin);
            }

            //Dès qu'une case est analysée, on la retire des cases à considérer
            listeOuverte.Remove(caseActuelle);
            listeFermee.Add(caseActuelle);

            //On cherche les cases voisines à la case trouvée, afin de trouver la prochaine case du chemin
            foreach (Case caseVoisine in GetListeVoisins(caseActuelle))
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
    private List<Case> GetListeVoisins(Case caseActuelle)
    {

        List<Case> listeVoisins = new List<Case>();

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

    //Getter pour une case
    public Case GetCase(int x, int y)
    {
        return grille.GetGridObject(x, y);
    }

    //Méthode qui rassemble toutes les cases sélectionnées et qui construit le chemin à suivre
    private List<Case> CalculerChemin(Case caseFin)
    {
        List<Case> chemin = new List<Case>();
        chemin.Add(caseFin);
        Case temp = caseFin;

        while (temp.casePrecedente != null)
        {
            chemin.Add(temp.casePrecedente);
            temp = temp.casePrecedente;
        }

        chemin.Reverse();

        return chemin;

    }

    //Méthode pour calculer la valeur H
    private int CalculerH(Case pt1, Case pt2)
    {

        int d_x = Mathf.Abs(pt1.positionX - pt2.positionX);
        int d_y = Mathf.Abs(pt1.positionY - pt2.positionY);
        int reste = Mathf.Abs(d_x - d_y);
        int coutFinal = MOUVEMENT_DIAGONAL * Mathf.Min(d_x, d_y) + MOUVEMENT_SUR_AXE * reste;

        return coutFinal;
    }

    //Méthode pour trouver la case qui a la valeurF la plus basse dans une liste
    private Case FPlusBas(List<Case> listeChemin)
    {
        Case fBas = listeChemin[0];

        for(int i = 0; i < listeChemin.Count; i++)
        {

            if (listeChemin[i].valeurF < fBas.valeurF)
            {
                fBas = listeChemin[i];
            }
        }

        return fBas;
    }


    //Getter qui retourne la grille utilisée
    public GridMathias GetGrid()
    {
        return grille;
    }
}
