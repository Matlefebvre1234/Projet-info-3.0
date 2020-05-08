using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathias : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Fonction2(135));
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Fonction(int n)
    {
        int total = 0;
        if (n > 0) total = 2 * n - 1 + Fonction(n - 1);

        return total;
    }

    public int Fonction2(int n)
    {
        int total2 = 0;

        if (n < 16)
        {
            total2 = n;
            Debug.Log(1);
        }

        else if (n >= 16 && n <= 24)
        {
            total2 = n - 15;
            Debug.Log(2);
        }

        else
        {
            total2 = 1 + Mathf.Min(Fonction2(n - 1), Fonction2(n - 15), Fonction2(n - 25));
            Debug.Log(3);
        }

        return total2;
    }

    public int Fonction3(int n)
    {

        int total3 = 0;
        int[] array = new int[n+1] ;

        for (int i = 0; i < n; i++)
        {
            Debug.Log(i);
            if (n < 16) total3 = i;
            else if (n >= 16 && n <= 24) total3 = i - 15;
            else total3 = 1 + Mathf.Min(array[i-1], array[i - 15], array[i - 25]);
            
            array[i] = total3;
        }
        return total3;
    }
}


