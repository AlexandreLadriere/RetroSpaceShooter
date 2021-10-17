using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image icon;

    public void SetHealth(int health) {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        icon.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int maxHealth) {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
        icon.color = gradient.Evaluate(1f);
    }
}
