using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth;
    public event Action<float> HealthChanged;
    public GameObject resetWindow;
    public GameController gameController;
    void Start()
    {
        var allGameSettings = Resources.LoadAll<GameSettings>("");
        maxHealth = (allGameSettings[0].PlayerHp != 0) ? allGameSettings[0].PlayerHp : maxHealth;
        currentHealth = maxHealth;
    }
    public void ChangeHealth( int value )
    {
        currentHealth += value;
        if (currentHealth <= 0)
        {
            Death();
        }
        else
        {
            float currentHealthAsPercantage = (float)currentHealth/maxHealth;
            HealthChanged?.Invoke(currentHealthAsPercantage);
        }
    }
    private void Death()
    {
        HealthChanged?.Invoke(0);
        Destroy(gameObject);
        gameController.GameOver();
    }

}
