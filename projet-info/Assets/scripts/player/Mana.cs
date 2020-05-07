using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public int manaMax = 0;
    public float manaJeu = 0;

    public BarreMana barreMana;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Mana", 0);
        manaJeu = 0;

        if (PlayerPrefs.GetInt("Niveau Difficulté") == 1)
        {
            manaMax = 200;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
        {
            manaMax = 150;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
        {
            manaMax = 100;
        }

        if (barreMana != null)
        {
            barreMana.SetManaMin(manaJeu);
            barreMana.SetManaMax(manaMax);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Niveau Difficulté") == 1)
        {
            manaMax = 200;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
        {
            manaMax = 150;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
        {
            manaMax = 100;
        }
    }

    public void SetManaJoueur (int mana)
    {
        if(barreMana != null)
        {
            if (manaJeu < manaMax)
            {
                PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") + mana);
            }
            if (mana > manaMax)
            {
                manaJeu = manaMax;
            }

            barreMana.SetMana(PlayerPrefs.GetInt("Mana"));
        }
        
    }
}
