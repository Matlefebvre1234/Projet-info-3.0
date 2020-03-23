using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineKitSoin : MonoBehaviour
{
    public GameObject kitSoin;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(kitSoin, transform.position - new Vector3(0, 0.934f, 1), Quaternion.identity);
        }
    }
}
