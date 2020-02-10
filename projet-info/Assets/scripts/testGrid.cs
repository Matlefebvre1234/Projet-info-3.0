using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGrid : MonoBehaviour
{
    public int hauteur = 14;
    public int largeur = 22;
    public float dimCell = 0.5f;
    private Vector3 origine = new Vector3(8, 1);
    private Transform joueur;
    private Grid<Node> grid;
    private Vector3 posJ = new Vector3();
    public GameObject sousPosJ;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid<Node>(largeur, hauteur, dimCell, origine, (Grid<Node> g ,int x ,int y) => new Node(g,x,y));
        joueur = GameObject.FindGameObjectWithTag("Player").transform;
        SamPathfinding path = new SamPathfinding(largeur, hauteur, dimCell, origine);
    }

    private void Update()
    {
        //posJ.x = joueur.position.x;
        //posJ.y = joueur.position.y;
        //grid.ValeurArrondie(posJ);
    }
}
