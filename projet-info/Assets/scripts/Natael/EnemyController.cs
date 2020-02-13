using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float raycastMaxDistance = 10f;

    private const int OBSTACLE_LAYER = 1;
    private Rigidbody2D body;
    private float originOffset = 0.5f;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastCheckUpdate();
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
            Vector2 direction = new Vector2(1, 0);

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