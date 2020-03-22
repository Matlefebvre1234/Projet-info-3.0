using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineKitSoin : MonoBehaviour
{
    public GameObject kitSoin;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnterTrigger2D(Collider2D collider)
    {
        Debug.Log("allo");
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(kitSoin, (Vector2)transform.position - new Vector2(0.25f, 0.25f), Quaternion.identity);
            Debug.Log("allo");
        }
    }
}
