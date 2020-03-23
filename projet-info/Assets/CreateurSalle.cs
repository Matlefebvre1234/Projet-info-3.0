using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateurSalle : MonoBehaviour

{

    public int nBEnnemiesTotal = 0;
    private int compteurEnnemies = 0;
    [SerializeField] GameObject[] listSalle;
    [SerializeField] GameObject[] listSalleBoss;
    public GameObject[] listPrefabMonstres;
    public GameObject[] spawnPoints;
    
                            

    // Start is called before the first frame update
    void Start()
    {
      
        CreerSalle();
        SpawnEnnemies();

    }

    private void SpawnEnnemies()
    {
        //nBEnnemiesTotal = FindObjectOfType<SceneLoader>().GetNumeroSalle();
        compteurEnnemies = nBEnnemiesTotal;
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        do
        {
            int nbRandom = Mathf.CeilToInt(Random.Range(0.1f, listPrefabMonstres.Length -1));
            int nbRandomSpawn = Mathf.CeilToInt(Random.Range(0.1f, spawnPoints.Length - 1));
            int difficulteMonstre = listPrefabMonstres[nbRandom].GetComponent<DifficulteEnnemi>().GetDifficulte();
            if (difficulteMonstre <= compteurEnnemies)
            {
                
                Instantiate(listPrefabMonstres[nbRandom], spawnPoints[nbRandomSpawn].transform.position,Quaternion.identity);
                compteurEnnemies -= difficulteMonstre;
            }

        } while (compteurEnnemies > 0);
    }

    private void CreerSalle()
    {
        int nombreRandom = Mathf.CeilToInt(Random.Range(0.1f, listSalle.Length -1));
        Instantiate(listSalle[nombreRandom]);
    }


    
}
