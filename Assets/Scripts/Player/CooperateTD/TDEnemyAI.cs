using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TDEnemyAI : MonoBehaviour
{
    public TDEnemyData tdEnemyData;
    public Transform endPoint;
    public bool has = false;
    
    

    public float currentHealth;

    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        endPoint = FindObjectOfType<TDEnemyEndPoint>().transform;
        currentHealth = tdEnemyData.health;

        navMeshAgent.speed = tdEnemyData.walkSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination( endPoint.position );
    }

    public bool isAlive()
    {
        return currentHealth >= 0.0f;
    }

    public void TakeDamage( float damage )
    {
        if ( isAlive() )
        {
            currentHealth -= damage;
            if ( !isAlive() )
            {
                Destroy( this.gameObject );
            }
        }
    }

    public IEnumerator SlowDown( float factor, float lastingTime )
    {
        if ( isAlive() )
        {
            var temp = tdEnemyData.walkSpeed * factor;
            navMeshAgent.speed = temp;
            yield return new WaitForSeconds( lastingTime );
            navMeshAgent.speed = tdEnemyData.walkSpeed;
        }
    }

    private void OnDestroy()
    {
        CooperateTDManager.Instance.currentEnemyCount--;
    }
}
