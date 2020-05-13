using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCamera : MonoBehaviour
{

    public GameObject camera1;
    public GameObject camera2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (camera1.activeSelf)
            {
                Debug.Log("Camera 1-> 2");
                camera1.SetActive(false);
                camera2.SetActive(true);
            }
            else if (camera2.activeSelf)
            {
                Debug.Log("Camera 2-> 1");
                camera2.SetActive(false);
                camera1.SetActive(true);
            }
        }
    }
}
