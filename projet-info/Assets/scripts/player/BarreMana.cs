using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreMana : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image couleur;

    public void Start()
    {
        slider.value = 0;
    }

    public void SetManaMin(float mana)
    {
        slider.value = mana;

        couleur.color = gradient.Evaluate(1f);
    }

    public void SetManaMax(int mana)
    {
        slider.maxValue = mana;
    }


    public void SetMana(float mana)
    {
        slider.value = mana;
        couleur.color = gradient.Evaluate(slider.normalizedValue);
    }
}
