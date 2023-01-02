using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int id;
    public float health;
    public float maxHealth = 100.0f;

    public void Initialize( int _id )
    {
        id = _id;
        health = maxHealth;
    }

    public void SetHealth( float _health )
    {
        health = _health;

        if ( health <= 0.0f )
        {
            OldScript.GameManager.enemies.Remove( id );
            Destroy( gameObject );
        }
    }
}
