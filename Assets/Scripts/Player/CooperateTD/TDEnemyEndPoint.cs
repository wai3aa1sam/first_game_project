
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDEnemyEndPoint : MonoBehaviour
{
    private void OnTriggerEnter( Collider other )
    {
        if ( other.CompareTag( "Enemy" ) )
        {
            var enemy = other.GetComponent<TDEnemyAI>();
            CooperateTDManager.Instance.DecreaseLive( enemy.tdEnemyData.damage );
            Destroy( other.gameObject );
        }
    }
}
