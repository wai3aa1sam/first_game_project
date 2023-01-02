using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage( float damage )
    {
        if ( IsAlive() )
        {
            currentHealth -= damage;
            if ( !IsAlive() )
            {
                Die();
            }
        }
    }

    public bool IsAlive()
    {
        return currentHealth > 0.0f;
    }

    private void Die()
    {
        
    }
}
