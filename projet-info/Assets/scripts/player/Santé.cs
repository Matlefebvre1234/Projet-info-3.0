using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santé : MonoBehaviour
{
    public float santeeMax = 100;
    public float santee;
    public float armure = 1;
    public BarreSantee barreSante;
    public AudioSource aS;
    private CreateurSalle createurSalle;
    private SceneLoader scene;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<CreateurSalle>() != null)
        {
            createurSalle = FindObjectOfType<CreateurSalle>().GetComponent<CreateurSalle>();
        }
        if (FindObjectOfType<SceneLoader>() != null)
        {
            scene = FindObjectOfType<SceneLoader>().GetComponent<SceneLoader>();
        }

        if(gameObject.tag == "Player")
        {

            if (PlayerPrefs.GetInt("Niveau") == 1)
            {
                santee = santeeMax;
                if (barreSante != null)
                    barreSante.SetSanteeMax(santee);
            }
            else if (PlayerPrefs.GetInt("Niveau") == 2)
            {
                santee = santeeMax + 50;
            }
            else if (PlayerPrefs.GetInt("Niveau") == 3)
            {
                santee = santeeMax + 75;
            }
            else if (PlayerPrefs.GetInt("Niveau") == 4)
            {
                santee = santeeMax + 100;
            }
            else if (PlayerPrefs.GetInt("Niveau") == 5)
            {
                santee = santeeMax + 125;
            }
            else if (PlayerPrefs.GetInt("Niveau") == 6)
            {
                santee = santeeMax + 150;
            }



        }

        santee = santeeMax;
        if (barreSante != null)
            barreSante.SetSanteeMax(santee);

    }

    // Update is called once per frame
    void Update()
    {
        if (santee <= 0)
        {
            if (gameObject.tag != "Player" && gameObject.GetComponent<InvocateurInvoque>() == null)
            {
                createurSalle.EnnemiesTuer();
            }
            else if(gameObject.tag == "Player")
            {
                scene.GameOver();
            }
           
            Destroy(gameObject);
        }
    }

    public void attaque(float qteAttaque)
    {
   
        santee = santee - (qteAttaque/armure);
        if (barreSante != null)
        {
            barreSante.SetSantee(santee);
        }

        if (aS != null)
        { 
        if (aS.isPlaying == false)
        {
            aS.Play();
        }
        }
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

    public void Armure(float protection)
    {
        armure = protection;
    }

    public void KitSoin(float regeneration)
    {
        float surplus;

        if(regeneration < santeeMax)
        {
            santee += regeneration;

            if(santee > santeeMax)
            {
                surplus = santee - santeeMax;
                santee -= surplus;
            }
        }
            barreSante.SetSantee(santee);
    }

    public void SetSantee(int santeeMax_1, int santee_1)
    {
        santeeMax = santeeMax_1;
        santee = santee_1;
        barreSante.SetSantee(santee);
    }
}
