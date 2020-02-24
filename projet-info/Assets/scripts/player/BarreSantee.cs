using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreSantee : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image couleur;

    public void SetSanteeMax(float santee)
    {
        slider.maxValue = santee;
        slider.value = santee;

        couleur.color = gradient.Evaluate(1f);
    }

    public void SetSantee(float santee)
    {
        slider.value = santee;
        couleur.color = gradient.Evaluate(slider.normalizedValue);
    }
}
