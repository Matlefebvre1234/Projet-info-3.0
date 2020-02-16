using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hauteur = 14;
    public int largeur = 22;
    public float raycastMaxDistance = 10f;
    //public GameObject player;
    //public GameObject IA;
    public int rangeIAMax = 3;
    public int rangeIAMin = -3;
    public int rangeAttaquePlayer = 4;
    public float speed = 0.02f;

    private NatPathfinding pathfinding;
    private const int OBSTACLE_LAYER = 1;
    private Rigidbody2D body;
    private float originOffset = 0.5f;
    private NatGrid grid;
    private Vector3 origine = new Vector3(8, 1);
    private List<NatNode> path;
    private int node = 0;
    private float elapseTime = 0;
    private float dimensionCellule = 0.5f;
    private int randomTime = 0;

    GameObject player;

    void Start()
    {
        pathfinding = new NatPathfinding(largeur, hauteur);
        body = GetComponent<Rigidbody2D>();
        grid = new NatGrid(largeur, hauteur, 0.5f, origine);
        //path = null;
        player = GameObject.FindGameObjectWithTag("Player");
        //elapseTime = 0;
        //randomTime = 0;

        bougerRadom();
    }

    void Update()
    {
        if (elapseTime == randomTime)
        {
            bougerRadom();
            Debug.Log("chemin");
        }

        elapseTime += 1 * Time.deltaTime;
        //tirerIA();

        suivrePath();
    }

    public void tirerIA()
    {
        Vector2 VecteurUnitaire = (Vector2)player.transform.position - (Vector2)transform.position;
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, VecteurUnitaire);

        //if(hit)
        //Debug.DrawRay(transform.position, VecteurUnitaire, Color.green, 0.5f);
    }

    public void bougerRadom()
    {
        //float rangeAttaque = Vector2.Distance(transform.position, player.transform.position);

        pathfinding.getGrid().GetXY(transform.position, out int x, out int y);


        int randomx = Random.Range(rangeIAMin, rangeIAMax);
        int randomy = Random.Range(rangeIAMin, rangeIAMax);


        while ((x + randomx) >= largeur || ((x + randomx) <= 0))
        {
            randomx = Random.Range(rangeIAMin, rangeIAMax);
        }

        while ((y + randomy) >= hauteur || (y + randomy) <= 0)
        {
            randomx = Random.Range(rangeIAMin, rangeIAMax);
        }

        path = pathfinding.FindPath(x, y, x + randomx, y + randomy);



    }

    public void suivrePath()
    {
        if (path != null)
        {
            pathfinding.getGrid().GetWorldXY(new Vector2(path[node].x, path[node].y), out float z, out float w);
            Vector2 targetPosition = new Vector2(z, w);

            if (Vector2.Distance(transform.position, targetPosition) > 0.0001f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
            }
            else
            {
                node++;
                if (node >= path.Count)
                {
                    node = 0;
                    path = null;
                    elapseTime = 0;
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
    }
}