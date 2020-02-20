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
    private Grid grid;
    private Vector3 posJ = new Vector3();
    public GameObject PosJoueur;
    public SamPathfinding samPathfinding;
    public GameObject demon;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(largeur, hauteur, dimCell, origine);
        samPathfinding = new SamPathfinding(largeur, hauteur, dimCell, origine);
        demon = new GameObject();
        PosJoueur = new GameObject();
        demon = GameObject.FindGameObjectWithTag("Demon");
        PosJoueur = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        grid.GetXY(demon.transform.position, out int x, out int y);
        grid.GetXY(PosJoueur.transform.position, out int x1, out int y1);
       // Debug.Log(x + ", " + y);

        List<SamNode> chemin = samPathfinding.TrouverChemin(x, y, x1, y1);
        if (chemin != null)
        {
            for (int i = 0; i < chemin.Count - 1; i++)
            {
                Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * dimCell + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 5f);
            }
        }
    }
}
