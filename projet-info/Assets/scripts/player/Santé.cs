using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santé : MonoBehaviour
{
    public float santeeMax = 100;
    public float santee;
    public BarreSantee barreSante;
    //MyData dataSaved = new MyData();

    //public void SaveGame()
    //{
    //    MyData data = new MyData();
    //    data.playerHealth = santee;
    //    data.playerPosition = Vector3.zero;
    //
    //    string serializedObject = JsonUtility.ToJson(data);
    //
    //    PlayerPrefs.SetString("playerProgress", serializedObject);
    //}
    //
    //public MyData LoadGame()
    //{
    //    string serializedObject = PlayerPrefs.GetString("playerProgress");
    //
    //    MyData data = JsonUtility.FromJson<MyData>(serializedObject);
    //
    //    return data;
    //}

    // Start is called before the first frame update
    void Start()
    {
        //if(dataSaved.Equals(null))
        //{
        //    santee = santeeMax;
        //}
        //else
        //{
        //    santee = dataSaved.playerHealth;
        //}
        santee = santeeMax;
        if(barreSante != null)
        barreSante.SetSanteeMax(santee);
    }

    // Update is called once per frame
    void Update()
    {
        if (santee <= 0)
        {

            Destroy(gameObject);
        
        }
    }

    public void attaque(float qteAttaque)
    {
   
        santee = santee - qteAttaque;
        if (barreSante != null)
            barreSante.SetSantee(santee);
    }

    public bool IsDead (bool b)
    {
        if (santee == 0)
        {
            b = true;
        }
        else 
        {
            b = false;
        }

        return b;
    }
}
