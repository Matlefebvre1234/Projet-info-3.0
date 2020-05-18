using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CreateurSalle : MonoBehaviour

{

    private int nbCompteurEnnemiesTotal;
    public int nBEnnemiesTotal = 0;
    private int compteurEnnemies = 0;
    [SerializeField] GameObject[] listSalle;
    [SerializeField] GameObject[] listSalleBoss;
    [SerializeField] GameObject SalleShop;

    public GameObject[] listPrefabMonstres;
    public GameObject[] listePrefabMana;

    private GameObject spawnJoueur;
    private int difficulteMonstre;

    public GameObject Player;

    //private int compteurDeSalleTotal = 0;
    private int compteurDeSalleTotal = 1;
    public int compteurDeSalle = 1;
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
        PlayerPrefs.SetInt("Score", -1);  
        nBEnnemiesTotal = 0;
        CreerSalle();

    }

    private void Update()
    {
        if (nBEnnemiesTotal <= 0 && AllEnnemySpawn)
        {            
            PlayerPrefs.SetInt("Enemy mort", 1);
            porte.porteOuverte = true;
            
        }

       if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
            nBEnnemiesTotal = 0;
            
            for(int i =0;i< list.Length;i++)
            {

                Destroy(list[i].gameObject);
            }
        }
       if(PlayerPrefs.GetInt("Meilleur Score") < PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Meilleur Score", PlayerPrefs.GetInt("Score"));
        }
    }
    private void SpawnerMana(int nbPotions)
    {
        int nbRandom = 0;
        List<GameObject> spawnPoints = new List<GameObject>();
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Spawn"));

        for (int i = 0; i < nbPotions; i++)
        {
            
          int nbRandomSpawn = Mathf.CeilToInt(UnityEngine.Random.Range(0.1f, spawnPoints.Count - 1));

            if(PlayerPrefs.GetInt("Niveau Difficulté") == 1)
            {
                nbRandom = UnityEngine.Random.Range(0, listePrefabMana.Length + 3);
            }
            if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
            {
                nbRandom = UnityEngine.Random.Range(0, listePrefabMana.Length + 2);
            }
            if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
            {
                nbRandom = UnityEngine.Random.Range(0, listePrefabMana.Length + 1);
            }
            if (nbRandom > listePrefabMana.Length)
          {
              nbRandom = 1;
          }
          else
          {
                nbRandom = 0;
          }
          float nbRandomX = UnityEngine.Random.Range(-0.5f, 0.5f);
          float nbRandomY = UnityEngine.Random.Range(-0.5f, 0.5f);

        
        Instantiate(listePrefabMana[nbRandom], spawnPoints[nbRandomSpawn].transform.position + new Vector3(nbRandomX, nbRandomY, 0), Quaternion.identity);
        }
    }

    private void SpawnEnnemies()
    {
        nbCompteurEnnemiesTotal = compteurDeSalleTotal;
        compteurEnnemies = nbCompteurEnnemiesTotal;

        List<GameObject> spawnPoints = new List<GameObject>();
        spawnPoints.AddRange(GameObject.FindGameObjectsWithTag("Spawn"));
              
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



        AllEnnemySpawn = true;
    }

    private void CreerSalle()
    {
  
        if(compteurDeSalle == 5)
        {
           

            Instantiate(SalleShop);
            nBEnnemiesTotal = 0;
            AllEnnemySpawn = true;
        }
        else if( compteurDeSalle == 10)
        {
            
            int n = Mathf.CeilToInt(UnityEngine.Random.Range(0.1f, listSalleBoss.Length - 1));
            //Instantiate(listSalle[compteurDeSalle]);
            Instantiate(listSalleBoss[n]);
            nBEnnemiesTotal = 1;
            AllEnnemySpawn = true;
        }
        else if (compteurDeSalle == 11)
        {
            
            
            Instantiate(SalleShop);
            compteurDeSalle = 1;
            nBEnnemiesTotal = 0;
            AllEnnemySpawn = true;
        }
        else if(compteurDeSalle != 5 && compteurDeSalle != 10 && compteurDeSalle != 11  )
        {
            int nombreRandom = Mathf.CeilToInt(UnityEngine.Random.Range(0.1f, listSalle.Length - 1));
            //Instantiate(listSalle[compteurDeSalle]);
            Instantiate(listSalle[nombreRandom]);
            if (PlayerPrefs.GetInt("Niveau Difficulté") == 1)
            {
                SpawnerMana(3);
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
            {
                SpawnerMana(2);
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
            {
                SpawnerMana(1);
            }
            SpawnEnnemies();
        }
     

        spawnJoueur = GameObject.FindGameObjectWithTag("SpawnJoueur");
        Player.transform.position = spawnJoueur.transform.position;
        porte = FindObjectOfType<ChangementNiveau>().GetComponent<ChangementNiveau>();
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
    }
    public void ProchainNiveau()
    {
        AllEnnemySpawn = false;
        PlayerPrefs.SetInt("Enemy mort", 1);

        compteurDeSalleTotal++;
        compteurDeSalle++;

        GameObject[] mine = GameObject.FindGameObjectsWithTag("Mine");
        foreach (GameObject enemy in mine)
            GameObject.Destroy(enemy);

        GameObject[] toile = GameObject.FindGameObjectsWithTag("PiegeAuSol");
        foreach (GameObject enemy in toile)
            GameObject.Destroy(enemy);

        GameObject[] fleche = GameObject.FindGameObjectsWithTag("AttackEnnemies");
        foreach (GameObject enemy in fleche)
            GameObject.Destroy(enemy);

        GameObject[] mana_small = GameObject.FindGameObjectsWithTag("mana_small");
        foreach (GameObject enemy in mana_small)
            GameObject.Destroy(enemy);

        GameObject[] mana_medium = GameObject.FindGameObjectsWithTag("mana_medium");
        foreach (GameObject enemy in mana_medium)
            GameObject.Destroy(enemy);

        Bloob2[] bloob = FindObjectsOfType<Bloob2>();
        foreach (Bloob2 enemy in bloob)
            GameObject.Destroy(enemy.gameObject);



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
        Debug.Log("Ennemie tuer = --");
        nBEnnemiesTotal--;
    }    
}
