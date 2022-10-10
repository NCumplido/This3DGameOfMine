using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sldrHealthFill;
    public void SetMaxHealth(int health)
    {
        sldrHealthFill.maxValue = health;
        sldrHealthFill.value = health;
    }

    public void SetHealth(int health)
    {
        sldrHealthFill.value = health;
    }
}
