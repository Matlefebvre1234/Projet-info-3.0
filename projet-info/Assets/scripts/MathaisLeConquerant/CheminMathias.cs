using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheminMathias
{
    private GridMathias grille;
    public int positionX;
    public int positionY;

    public int valeurG;
    public int valeurH;
    public int valeurF;

    public Boolean obstacle = false;

    public CheminMathias casePrecedente;

    //Constructeur avec une grille
    public CheminMathias(GridMathias n_grille, int n_x, int n_y)
    {
        grille = n_grille;
        positionX = n_x;
        positionY = n_y;
    }

    //Constructeur sans grille
    public CheminMathias(int n_x, int n_y)
    {
        grille = null;
        positionX = n_x;
        positionY = n_y;
    }

    //Méthode qui sert à calculer la valeur de f
    public void CalculerF()
    {
        valeurF = valeurG + valeurH;
    }

    //Méthode qui sert à indiquer qu'il y a un obstacle sur la case que l'intelligence artificielle ne peut pas traverser
    public void SetObstacleTrue()
    {
        obstacle = true;
    }

    //Setter pour la position en x de la case
    public void SetX(int x)
    {
        this.positionX = x;
    }

    //Setter pour la position en y de la case
    public void SetY(int y)
    {
        this.positionY = y;
    }

    //Getter pour savoir si un obstacle est présent sur la case
    public bool GetObstacle()
    {
        return obstacle;
    }
}

