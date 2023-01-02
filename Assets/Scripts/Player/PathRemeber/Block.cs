using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Party.PathRemember
{
    public class Block : MonoBehaviour
    {
        public GameObject EFXPrefab;
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void Start()
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");     
            Physics.IgnoreCollision( enemy.GetComponent<Collider>(), _collider );
        }

        public IEnumerator StartTheGame()
        {
            var efx = Instantiate( EFXPrefab, transform.position, Quaternion.identity );

            gameObject.SetActive( false );
            
            yield return new WaitForSeconds( 1.5f );
            
            Destroy( efx );

            yield return new WaitForSeconds( 2.0f );
            
            Destroy( gameObject );
        }
    }
}

