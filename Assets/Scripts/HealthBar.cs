using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image healthBarFilling;
    [SerializeField]
    Health health;
    private void Awake() 
    {
       health.HealthChanged += OnHealthChanged;
    }
    private void OnDestroy()
    {
        health.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(float valueAsPercantage)
    {
        healthBarFilling.fillAmount = valueAsPercantage;
    }
}
