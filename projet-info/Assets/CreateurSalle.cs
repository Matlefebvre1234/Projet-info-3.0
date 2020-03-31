using System.Collections;
using System.Collections.Generic;
using System;
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
    //private int compteurDeSalleTotal = 0;
    private int compteurDeSalleTotal = 1;
    private int compteurDeSalle = 1;
    private ChangementNiveau porte;
   
    private bool AllEnnemySpawn = false;
    private bool chargement = false;
    private bool changerSalle = false;
    float tempChargement = 0f;

    public string Mine;

    public string barricade;

    public string flèche;





    // Start is called before the first frame update
    void Start()
    {
        
        CreerSalle();
      

    }

    private void Update()
    {
        if (nBEnnemiesTotal <= 0 && AllEnnemySpawn)
        {
          
            porte.porteOuverte = true;
        }

        //if(compteurDeSalle > listSalle.Length)
        //{
        //    compteurDeSalle = 0;
        //}
     //   if (chargement ==true) tempChargement = tempChargement + 1 * Time.deltaTime;
    }
    private void SpawnEnnemies()
    {
        nbCompteurEnnemiesTotal = compteurDeSalleTotal;
        compteurEnnemies = nbCompteurEnnemiesTotal;


        List<GameObject> spawnPoints = new List<GameObject>();
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Spawn"));


    
        
        Debug.Log(spawnPoints.Count);
        do
        {
            int nbRandom = Mathf.CeilToInt(UnityEngine.Random.Range(0.1f, listPrefabMonstres.Length -1));
            int nbRandomSpawn = Mathf.CeilToInt(UnityEngine.Random.Range(0.1f, spawnPoints.Count - 1));
            float nbRandomX = UnityEngine.Random.Range(-0.5f, 0.5f);
            float nbRandomY = UnityEngine.Random.Range(-0.5f, 0.5f);
             difficulteMonstre = listPrefabMonstres[nbRandom].GetComponent<DifficulteEnnemi>().GetDifficulte();
            if (difficulteMonstre <= compteurEnnemies)
            {
                
                Instantiate(listPrefabMonstres[nbRandom], spawnPoints[nbRandomSpawn].transform.position + new Vector3(nbRandomX,nbRandomY,0),Quaternion.identity);
              //  Debug.Log(spawnPoints[nbRandomSpawn].transform.position);
                compteurEnnemies -= difficulteMonstre;
                nBEnnemiesTotal++;

            }

        } while (compteurEnnemies > 0);
        spawnPoints.Clear();

        GameObject[] spawn = GameObject.FindGameObjectsWithTag("Spawn");
        foreach (GameObject s in spawn)
            GameObject.Destroy(s);

        Debug.Log(spawnPoints.Count);
        AllEnnemySpawn = true;
    }

    private void CreerSalle()
    {
        
        int nombreRandom = Mathf.CeilToInt(UnityEngine.Random.Range(0.1f, listSalle.Length -1));
        //Instantiate(listSalle[compteurDeSalle]);
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

        GameObject[] mine = GameObject.FindGameObjectsWithTag("Mine");
        foreach (GameObject enemy in mine)
            GameObject.Destroy(enemy);

        GameObject[] barricade = GameObject.FindGameObjectsWithTag("Barricade");
        foreach (GameObject enemy in barricade)
            GameObject.Destroy(enemy);

        GameObject[] fleche = GameObject.FindGameObjectsWithTag("AttackEnnemies");
        foreach (GameObject enemy in fleche)
            GameObject.Destroy(enemy);

        GameObject salle = GameObject.FindGameObjectWithTag("Salle");
        FindObjectOfType<GrilleMonstresMat>().DestroyGrid();
        murTransparent[] a = FindObjectsOfType<murTransparent>();
        foreach (murTransparent s in a)
            GameObject.Destroy(s);
      
        chargement = true;
        Destroy(salle.gameObject);

        CreerSalle();

     
    }

    public void EnnemiesTuer()
    {
        nBEnnemiesTotal--;


    }


    
}
