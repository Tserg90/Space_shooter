using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMeteor : MonoBehaviour
{
    private int maxHealth = 1;
    private float currentHealth;
    private void Start()
    {
        var allGameSettings = Resources.LoadAll<GameSettings>("");
        maxHealth = (allGameSettings[0].Meteor1Hp != 0) ? allGameSettings[0].Meteor1Hp : maxHealth;
        if (gameObject.tag == "Meteor2")
        {
            maxHealth = (allGameSettings[0].Meteor2Hp != 0) ? allGameSettings[0].Meteor2Hp : maxHealth;
        }
        currentHealth = maxHealth;
        
    }

    public bool ChangeHealth( int value )
    {
        float newValue = (float)(value/2.0);
        currentHealth += newValue;
        if (currentHealth <= 0.0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}