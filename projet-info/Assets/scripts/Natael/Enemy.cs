using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int hauteur = 14;
    public int largeur = 22;

    public GameObject player;
    public GameObject enemy;

    private NatPathfinding pathfinding;
    private Vector3 origine = new Vector3(8, 1);
    private NatGrid grid;

    void Start()
    {
        pathfinding = new NatPathfinding(largeur, hauteur);
        grid = new NatGrid(largeur, hauteur, 0.5f, origine);
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            //Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //pathfinding.getGrid().GetXY(positionSouris, out int x, out int y);

            Vector3 positionPlayer = new Vector3(player.transform.position.x, player.transform.position.y);
            Vector3 positionEnemy = new Vector3(enemy.transform.position.x, enemy.transform.position.y);


            grid.GetXY(positionPlayer, out int z, out int w);
            grid.GetXY(positionEnemy, out int x, out int y);


            List<NatNode> path = pathfinding.FindPath(z, w, x, y);
        //}

    }
}
