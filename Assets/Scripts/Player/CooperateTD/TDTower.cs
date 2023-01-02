using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTower : MonoBehaviour
{
    public TDTowerData tdTowerData;

    public Transform shootTransform;
    public TDEnemyAI target;
    private float attackCounter = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnAttack();
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position to show the firing range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, tdTowerData.attackArea);
    }

    // Detect an Enemy, aim and fire
    void OnTriggerStay(Collider other)
    {
        if (target == null && other.CompareTag( "Enemy" ))
        {

            target = other.GetComponent<TDEnemyAI>();
            // if ( !target.isAlive() )
            // {
            //     target = null;
            //     return;   
            // }
            SetAttackCounter();
        }

    }
    // Stop firing
    void OnTriggerExit(Collider other)
    {
        if ( target && other.CompareTag( "Enemy" ) )
        {
            target = null;
            OffAttackCounter();
        }
    }

    void OnAttack()
    {
        if ( target )
        {
            attackCounter += Time.deltaTime;
            if ( attackCounter >= tdTowerData.attackTime )
            {
                if ( !target.isAlive() )
                {
                    target = null;
                    OffAttackCounter();
                    return;   
                }

                if ( tdTowerData.towerProjectile )
                {
                    var proj = Instantiate( tdTowerData.towerProjectile, shootTransform.position, Quaternion.identity );
                    proj.GetComponent<TDProjectile>().SetupProjectile( target.gameObject, tdTowerData.damage, tdTowerData.slowDownFactor );
                }
                else
                {
                    target.TakeDamage( tdTowerData.damage );
                }
                attackCounter -= tdTowerData.attackTime;
                if ( !target.isAlive() )
                {
                    target = null;
                    OffAttackCounter();
                }

            }
        }
    }

    private void SetAttackCounter()
    {
        attackCounter = 0;
    }

    private void OffAttackCounter()
    {
        attackCounter = Mathf.NegativeInfinity;
    }

    public TDEnemyAI GetTarget()
    {
        return target;
    }
}
