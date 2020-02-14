using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hauteur = 14;
    public int largeur = 22;
    public float raycastMaxDistance = 10f;
    public GameObject player;
    public GameObject IA;
    public int rangeIA = 6;
    public int randomTime = 2;
    public int rangeAttaquePlayer = 4;

    private NatPathfinding pathfinding;
    private const int OBSTACLE_LAYER = 1;
    private Rigidbody2D body;
    private float originOffset = 0.5f;
    private NatGrid grid;
    private Vector3 origine = new Vector3(8, 1);
    private List<NatNode> path;
    private int node = 0;
    private float elapseTime;
    private float dimensionCellule = 0.5f;


    void Start()
    {
        pathfinding = new NatPathfinding(largeur, hauteur);
        body = GetComponent<Rigidbody2D>();
        grid = new NatGrid(largeur, hauteur, 0.5f, origine);
    }

    void Update()
    {
        elapseTime += 1 * Time.deltaTime;
        tirerIA();

        if (elapseTime >= randomTime)
        {
            bougerRadom();
            elapseTime = 0;
        }

    }

    public void tirerIA()
    {
        Vector2 VecteurUnitaire = (Vector2)player.transform.position - (Vector2)transform.position;
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, VecteurUnitaire);

        Debug.DrawRay(transform.position, VecteurUnitaire, Color.green, 0.5f);
    }

    public void bougerRadom()
    {
        float rangeAttaque = Vector2.Distance(IA.transform.position, player.transform.position);
        if (rangeAttaque <= (rangeAttaquePlayer * dimensionCellule))
        {
            //Tirer plus vite et animation de IA faché !
        }
        else
        {
            Vector3 positionIA = new Vector3(IA.transform.position.x, IA.transform.position.y);
            grid.GetXY(positionIA, out int x, out int y);

            int randomx = Random.Range(2, rangeIA);
            int randomy = Random.Range(2, rangeIA);

            while ((x + randomx) >= largeur)
            {
                randomx = Random.Range(2, rangeIA);
            }

            while (Mathf.Abs (y + randomy) >= hauteur)
            {
                randomx = Random.Range(2, rangeIA);
            }

            Debug.Log("x" + (x +randomx));
            Debug.Log("y" + (y + randomy));

            path = pathfinding.FindPath(x, y, x + randomx, y + randomy);

            suivrePath();
        }
    }

    public void suivrePath()
    {
        pathfinding.getGrid().GetWorldXY(new Vector2(path[node].x, path[node].y), out float z, out float w);
        Vector2 targetPosition = new Vector2(z, w);

        if (Vector2.Distance(IA.transform.position, targetPosition) > 0.000001f)
        {
            IA.transform.position = Vector2.MoveTowards(transform.position, targetPosition, 0.1f);
        }

        node++;

        if(node >= path.Count)
        {
            path = null;
            node = 0;
        }
    }
}