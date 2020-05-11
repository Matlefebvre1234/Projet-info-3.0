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
        PlayerPrefs.SetFloat("Mana", 0);
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
            if((manaJeu + mana) <= 0)
            {
                manaJeu = 0;
                PlayerPrefs.SetFloat("Mana", 0);
            }
            else if ((manaJeu + mana) < manaMax)
            {
                manaJeu = manaJeu + mana;
                PlayerPrefs.SetFloat("Mana", manaJeu);
            }
            else if ((mana + manaJeu) >= manaMax)
            {
                manaJeu = manaMax;
               PlayerPrefs.SetFloat("Mana", manaMax);
            }

            barreMana.SetMana(manaJeu);

            Debug.Log("mana = " + PlayerPrefs.GetFloat("Mana"));
        }
        
    }
}
