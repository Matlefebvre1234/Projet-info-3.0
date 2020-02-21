using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeTransparent : MonoBehaviour
{
    public BarricadeTransparent trans;
    public GameObject barricade;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = barricade.GetComponent<SpriteRenderer>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "C4")
        {
            trans.transparenceTrue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "C4")
        {
            trans.transparenceFalse();
        }
    }

    public void transparenceTrue()
    {
      spriteRenderer.color = new Color(1, 1, 1, 0.50f);
        
    }

    public void transparenceFalse()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
       
    }
}
