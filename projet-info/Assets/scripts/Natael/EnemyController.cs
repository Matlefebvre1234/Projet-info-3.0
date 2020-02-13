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
    public int rangeIA = 3;

    private int frame = 0;
    private NatPathfinding pathfinding;
    private const int OBSTACLE_LAYER = 1;
    private Rigidbody2D body;
    private float originOffset = 0.5f;
    private NatGrid grid;
    private Vector3 origine = new Vector3(8, 1);



    void Start()
    {
        pathfinding = new NatPathfinding(largeur, hauteur);
        body = GetComponent<Rigidbody2D>();
        grid = new NatGrid(largeur, hauteur, 0.5f, origine);
    }

    void Update()
    {
        RaycastCheckUpdate();

        //Debug.Log("random = " + random);


        Vector3 positionIA = new Vector3(IA.transform.position.x, IA.transform.position.y);
        grid.GetXY(positionIA, out int x, out int y);

        if (frame == 0)
        {
            int randomx = Random.Range(-2, rangeIA);
            int randomy = Random.Range(-2, rangeIA);

            List<NatNode> path = pathfinding.FindPath(x, y, x + randomx, y + randomy);
            //IA.Move(path);

            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), new Vector3(path[i + 1].x, path[i + 1].y) * 0.5f + Vector3.one * 0.25f + new Vector3(4, 0.5f), Color.green, 5f);
                }
            }
        }
        else
        {
            //Nothing
        }

        frame++;
    }

    public void radom()
    {

    }

    public RaycastHit2D CheckRaycast(Vector2 direction)
    {
        float directionOriginOffset = originOffset * (direction.x > 0 ? 1 : -1);

        Vector2 startingPosition = new Vector2(transform.position.x + directionOriginOffset, transform.position.y);

        return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance, OBSTACLE_LAYER);

    }

    private bool RaycastCheckUpdate()
    {
        // Raycast button pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Launch a raycast in the forward direction from where the player is facing.
            Vector2 direction = new Vector2(0, 0);

            // If facing left, negative direction
            //if (anim.GetFloat("X") < 0)
            //{
            //    direction *= -1;
            //}


            // First target hit
            RaycastHit2D hit = CheckRaycast(direction);

            if (hit.collider)
            {
                //   Debug.Log("Hit the collidable object " + hit.collider.name);

                Debug.DrawRay(transform.position, hit.point, Color.red, 3f);
            }
            return true;
        }
        else
        {
            return false;
        }
    }


}