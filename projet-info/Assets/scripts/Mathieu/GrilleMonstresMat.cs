using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleMonstresMat : MonoBehaviour
{
    static MatGrid  grid;
    public int hauteur = 14;
    public int largeur = 22;
    public float dimCell =0.5f;
    public static Vector3 origine = new Vector3(8, 1);

   

    // Start is called before the first frame update
    void Start()
    {
     
        grid = new MatGrid(largeur, hauteur, dimCell, origine);

    }

    
    public MatGrid getGrid()
    {
        if(grid ==null) grid = new MatGrid(largeur, hauteur, dimCell, origine);

        return grid;

    }
    public float getdimCell()
    {
        return dimCell;
    }
    public void DestroyGrid()
    {

        grid = null;

    }
}
