using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatTesting : MonoBehaviour
{
    // Start is called before the first frame update
    public int hauteur = 14;
    public int largeur = 22;
    float origineMap_X = 2.5f;
    float origineMap_Y = 3.25f;
    private NatPathfinding pathfinding;
    private NatGrid grid;
    public GameObject player;
    public GameObject enemy;

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

            Vector3 positionPlayer = new Vector3(player.transform.position.x, player.transform.position.y);
            Vector3 positionEnemy = new Vector3(enemy.transform.position.x, enemy.transform.position.y);

            Debug.Log("Player is on : x, " + positionPlayer.x + ", y : " + positionPlayer.y);

            //Ça pète ici !!!!!
            grid.GetXY(positionPlayer, out int z, out int w);

            //Debug.Log("x, " + z + " y, " + w);

            List<NatNode> path = pathfinding.FindPath(z, w, x, y);
            //List<NatNode> path = pathfinding.FindPath(position.x, position.y, x, y);

            
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.Log("x, : " + path[i].x + "y : " + path[i].y);
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(path[i + 1].x, path[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 5f);
                }
            }
        }

    }
}
