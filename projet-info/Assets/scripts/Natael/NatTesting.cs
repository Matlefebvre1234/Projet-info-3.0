using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatTesting : MonoBehaviour
{
    // Start is called before the first frame update
    public int hauteur = 14;
    public int largeur = 22;
    private NatPathfinding pathfinding;
    public GameObject player;
    void Start()
    {
        pathfinding = new NatPathfinding(largeur, hauteur);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pathfinding.getGrid().GetXY(positionSouris, out int x, out int y);

            //Vector3 posx = new Vector3(player.transform.position.x, player.transform.position.y);

            //List<NatNode> path = pathfinding.FindPath((int)posx.x, (int)posx.y, x, y);
            List<NatNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.Log("x:" + path[i].x);
                    Debug.Log("y:" + path[i].y);
                    Debug.Log("x + 1:" + path[i + 1].x);
                    Debug.Log("y + 1:" + path[i + 1].y);
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(path[i + 1].x, path[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 5f);
                }
            }
        }

    }
}
