using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatTesting : MonoBehaviour
{
    // Start is called before the first frame update
    public int hauteur = 14;
    public int largeur = 22;
    private matPathfinding pathfinding;
    void Start()
    {
         pathfinding = new matPathfinding();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pathfinding.getGrid().GetXY(positionSouris, out int x, out int y);

            List<MatNode> chemin = pathfinding.FindPath(0, 0, x, y);
            if (chemin != null)
            {
                for (int i = 0; i < chemin.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(chemin[i].x, chemin[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4,0.5f), new Vector3(chemin[i + 1].x, chemin[i + 1].y) * 0.5f + Vector3.one * 0.25f +new Vector3(4, 0.5f), Color.green, 5f);
                }
            }
        }
        
    }
}
