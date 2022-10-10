using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sldrHealthFill;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(int health)
    {
        sldrHealthFill.maxValue = health;
        sldrHealthFill.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        sldrHealthFill.value = health;
        fill.color = gradient.Evaluate(sldrHealthFill.normalizedValue);
    }
}
