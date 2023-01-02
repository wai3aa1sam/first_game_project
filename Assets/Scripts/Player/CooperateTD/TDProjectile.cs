using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class TDProjectile : MonoBehaviour
{
    public enum SpecialEffect
    {
        None,
        Slow
    }

    public SpecialEffect specialEffect = SpecialEffect.None;
    public bool isSpread = true;
    public float projectSpeed = 5.0f;

    public float slowDownFactor = 1.0f;
    public float slowDownLastingTime = 3.0f;
    
    public float explosionRadius = 1.0f;
    public float explosionDist = 0.1f;

    public Transform projectileParent;

    private GameObject _target;
    private float _damage;
    

    public void SetupProjectile( GameObject target, float damage, float slowDownFactor )
    {
        _target = target;
        _damage = damage;
        this.slowDownFactor = slowDownFactor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( _target )
        {
            if ( Vector3.Distance( transform.position, _target.transform.position ) <= explosionDist )
            {
                if ( isSpread )
                {
                    ExplosionDamage( transform.position, explosionRadius );
                }
                else
                {
                    var enemy = _target.GetComponent<TDEnemyAI>();
                    enemy.SlowDown( slowDownFactor, slowDownLastingTime );
                    enemy.TakeDamage( _damage );
                }
                Destroy( this.gameObject );
            }
            transform.LookAt( _target.transform );
            transform.position += transform.forward * (projectSpeed * Time.deltaTime);
        }
        else
        {
            Destroy( gameObject );
        }
    }
    
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if ( hitCollider.CompareTag( "Enemy" ) )
            {
                var enemy = hitCollider.GetComponent<TDEnemyAI>();
                if ( specialEffect == SpecialEffect.Slow )
                {
                    enemy.SlowDown( slowDownFactor, slowDownLastingTime );
                }
                enemy.TakeDamage( _damage );
            }
        }
    }

    
    
    
}
