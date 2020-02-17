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
    public SamPathfinding samPathfinding;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid<Node>(largeur, hauteur, dimCell, origine, (Grid<Node> g ,int x ,int y) => new Node(g,x,y));
        samPathfinding = new SamPathfinding(largeur, hauteur, dimCell, origine);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grid.GetXY(positionSouris, out int x, out int y);

            List<SamNode> chemin = samPathfinding.TrouverChemin(0, 0, x, y);
            if (chemin != null)
            {
                for (int i = 0; i < chemin.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 5f);
                }
            }
        }

    }
}
