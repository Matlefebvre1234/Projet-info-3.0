using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && camera1.activeSelf == false)
        {
            camera2.SetActive(false);
            camera1.SetActive(true);
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
            }
        }
    }
}
