using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateurSalle : MonoBehaviour

{

    public int nbCompteurEnnemiesTotal;
    public int nBEnnemiesTotal = 0;
    private int compteurEnnemies = 0;
    [SerializeField] GameObject[] listSalle;
    [SerializeField] GameObject[] listSalleBoss;
    public GameObject[] listPrefabMonstres;
    private GameObject spawnJoueur;
    private int difficulteMonstre;
    public GameObject Player;
    private int compteurDeSalleTotal = 1;
    private int compteurDeSalle = 1;
    private ChangementNiveau porte;
   
    private bool AllEnnemySpawn = false;





    // Start is called before the first frame update
    void Start()
    {
        
        CreerSalle();
      

    }

    private void Update()
    {
        if (nBEnnemiesTotal <= 0 && AllEnnemySpawn) porte.porteOuverte = true;
      
    }
    private void SpawnEnnemies()
    {
        nbCompteurEnnemiesTotal = compteurDeSalleTotal;
        compteurEnnemies = nbCompteurEnnemiesTotal;
        GameObject[] spawnPoints =  GameObject.FindGameObjectsWithTag("Spawn");
        do
        {
            int nbRandom = Mathf.CeilToInt(Random.Range(0.1f, listPrefabMonstres.Length -1));
            int nbRandomSpawn = Mathf.CeilToInt(Random.Range(0.1f, spawnPoints.Length - 1));
            float nbRandomX = Random.Range(-0.5f, 0.5f);
            float nbRandomY = Random.Range(-0.5f, 0.5f);
             difficulteMonstre = listPrefabMonstres[nbRandom].GetComponent<DifficulteEnnemi>().GetDifficulte();
            if (difficulteMonstre <= compteurEnnemies)
            {
                
                Instantiate(listPrefabMonstres[nbRandom], spawnPoints[nbRandomSpawn].transform.position + new Vector3(nbRandomX,nbRandomY,0),Quaternion.identity);
                Debug.Log(spawnPoints[nbRandomSpawn].transform.position);
                compteurEnnemies -= difficulteMonstre;
                nBEnnemiesTotal++;

            }

        } while (compteurEnnemies > 0);
        AllEnnemySpawn = true;
    }

    private void CreerSalle()
    {
        
        int nombreRandom = Mathf.CeilToInt(Random.Range(0.1f, listSalle.Length -1));
        Instantiate(listSalle[nombreRandom]);
        spawnJoueur = GameObject.FindGameObjectWithTag("SpawnJoueur");
        Player.transform.position = spawnJoueur.transform.position;
        porte = FindObjectOfType<ChangementNiveau>().GetComponent<ChangementNiveau>();


        SpawnEnnemies();
    }
    public void ProchainNiveau()
    {
        AllEnnemySpawn = false;
       
        compteurDeSalleTotal++;
        compteurDeSalle++;
        GameObject salle = GameObject.FindGameObjectWithTag("Salle");
        FindObjectOfType<GrilleMonstresMat>().DestroyGrid();
        Destroy(salle.gameObject);
        
        CreerSalle();

    }

    public void EnnemiesTuer()
    {
        nBEnnemiesTotal--;


    }

    
}
