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

    public PathfindingMathias(int largeur, int hauteur)
    {
        grille = new GridMathias(largeur, hauteur, 0.5f, Origine, (GridMathias grille, int x, int y) => new CheminMathias(grille, x, y));
    }

    public GridMathias GetGrid()
    {
        return grille;
    }

    public List<CheminMathias> Chemin(int debutX, int debutY, int finX, int finY)
    {
        //Debug.Log(finX);
        //Debug.Log(finY);
        CheminMathias caseDebut = grille.GetGridObject(debutX, debutY);
        CheminMathias caseFin = grille.GetGridObject(finX, finY);

        listeOuverte = new List<CheminMathias>() { caseDebut };
        listeFermee = new List<CheminMathias>();

        for (int x = 0; x < grille.GetLargueur(); x++)
        {
            for (int y = 0; y < grille.GetHauteur(); y++)
            {
                CheminMathias pathNode = grille.GetGridObject(x, y);
                pathNode.g = int.MaxValue;
                pathNode.CalculerF();
                pathNode.casePrecedente = null;
            }
        }

        caseDebut.g = 0;
        caseDebut.h = CalculerH(caseDebut, caseFin);
        caseDebut.CalculerF();

        while(listeOuverte.Count > 0)
        {
            CheminMathias caseActuelle = FPlusBas(listeOuverte);

            if (caseActuelle == caseFin)
            {
                return CalculerChemin(caseFin);
            }

            listeOuverte.Remove(caseActuelle);
            listeFermee.Add(caseActuelle);

            

            foreach (CheminMathias caseVoisine in GetListeVoisins(caseActuelle))
            {

                if (listeFermee.Contains(caseVoisine))
                {
                    continue;
                }

                //Debug.Log(caseVoisine);

                int gTemp = caseActuelle.g + CalculerH(caseActuelle, caseVoisine);

                if(gTemp < caseVoisine.g)
                {
                    caseVoisine.casePrecedente = caseActuelle;
                    caseVoisine.g = gTemp;
                    caseVoisine.h = CalculerH(caseVoisine, caseFin);
                    caseVoisine.CalculerF();

                    if(!listeOuverte.Contains(caseVoisine))
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

        //Case de gauche
        if (caseActuelle.x - 1 >= 0)
        {
            listeVoisins.Add(GetCase(caseActuelle.x - 1, caseActuelle.y));

            if (caseActuelle.y - 1 >= 0)
            {
                listeVoisins.Add(GetCase(caseActuelle.x - 1, caseActuelle.y - 1));
            }

            if (caseActuelle.y + 1 < grille.GetHauteur())
            {
                listeVoisins.Add(GetCase(caseActuelle.x - 1, caseActuelle.y + 1));
            }
        }

        //À droite
        if (caseActuelle.x + 1 < grille.GetLargueur())
        {

            listeVoisins.Add(GetCase(caseActuelle.x + 1, caseActuelle.y));

            if (caseActuelle.y - 1 >= 0)
            {
                listeVoisins.Add(GetCase(caseActuelle.x + 1, caseActuelle.y - 1));
            }

            if (caseActuelle.y + 1 < grille.GetHauteur())
            {
                listeVoisins.Add(GetCase(caseActuelle.x + 1, caseActuelle.y + 1));
            }
        }

        if (caseActuelle.y - 1 >= 0)
        {
            listeVoisins.Add(GetCase(caseActuelle.x, caseActuelle.x - 1));
        }

        if (caseActuelle.y + 1 >= grille.GetHauteur())
        {
            listeVoisins.Add(GetCase(caseActuelle.x, caseActuelle.x + 1));
        }

        return listeVoisins;
    }

    public CheminMathias GetCase(int x, int y)
    {
        return grille.GetGridObject(x, y);
    }

    private List<CheminMathias> CalculerChemin(CheminMathias caseFin)
    {
        List <CheminMathias> chemin = new List<CheminMathias>();
        chemin.Add(caseFin);
        CheminMathias temp = caseFin;

        while(temp.casePrecedente != null)
        {
            chemin.Add(temp.casePrecedente);
            temp = temp.casePrecedente;
        }

        chemin.Reverse();

        return chemin;

    }

    private int CalculerH(CheminMathias pt1, CheminMathias pt2)
    {

        int d_x = Mathf.Abs(pt1.x - pt2.x);
        int d_y = Mathf.Abs(pt1.y - pt2.y);
        int reste = Mathf.Abs(d_x - d_y);
        int coutFinal = MOUVEMENT_DIAGONAL * Mathf.Min(d_x, d_y) + MOUVEMENT_SUR_AXE * reste;

        return coutFinal;
    }

    private CheminMathias FPlusBas(List<CheminMathias> listeChemin)
    {
        /*CheminMathias f_bas = listeChemin[0];
        for(int i = 1; i < listeChemin.Count; i++)
        {
            if(listeChemin[i].f < f_bas.f)
            {
                f_bas = listeChemin[i];
            }
        }

        //Debug.Log(f_bas.x);
       Debug.Log(f_bas.y);
       Debug.Log(f_bas.x);

        return f_bas;*/

        CheminMathias lowerFCostNode = listeChemin[0];
        for (int i = 0; i < listeChemin.Count; i++)
        {
            if (listeChemin[i].f < lowerFCostNode.f)
            {
                lowerFCostNode = listeChemin[i];
            }

        }

        Debug.Log(lowerFCostNode.y);
        Debug.Log(lowerFCostNode.x);

        return lowerFCostNode;
    }
}
