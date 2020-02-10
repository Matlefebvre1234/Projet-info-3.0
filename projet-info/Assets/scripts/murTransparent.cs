using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class murTransparent : MonoBehaviour {

    public GameObject[] mur;
    public SpriteRenderer[] spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0 ;i< mur.Length;i++)
        {
            spriteRenderer[i] = mur[i].GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    
    public void transparenceTrue()
    {
        for (int i = 0; i < mur.Length; i++)
        {
            spriteRenderer[i].color = new Color(1, 1, 1, 0.50f);
        }

    }
    public void transparenceFalse()
    {
        for (int i = 0; i < mur.Length; i++)
        {
            spriteRenderer[i].color = new Color(1, 1, 1, 1);
        }

    }
}
