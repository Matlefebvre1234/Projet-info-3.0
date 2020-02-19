using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMathias : MonoBehaviour
{

    private PathfindingMathias pathfinding;
    private int x;
    private int y;
    public int largeur;
    public int hauteur;

    // Start is called before the first frame update
    void Start()
    {
        pathfinding = new PathfindingMathias(14, 22);
    }

    private void update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionSouris.z = 0;

            Debug.Log("allo");

            pathfinding.GetGrid().GetXY(positionSouris, out x, out y);
            
            List<CheminMathias> chemin = pathfinding.Chemin(0, 0, x, y);

            if(chemin != null)
            {
                for(int i = 0; i < chemin.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3 (4, 0.5f), Color.blue, 5f);
                    Debug.Log(positionSouris.x + ", " + positionSouris.y + ", " + positionSouris.z);
                }
            }
        }
    }

}
