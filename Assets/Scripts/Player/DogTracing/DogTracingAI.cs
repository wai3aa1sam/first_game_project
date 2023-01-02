using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Party.DogTracing
{
    public class DogTracingAI : MonoBehaviour
    {
        
        
        
        public Transform player;

        public float speed = 3.0f;

        private Rigidbody _rigidbody;

        public float counter = 0.0f;
        public float speedUpCounter = 5.0f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            counter += Time.deltaTime;
            transform.LookAt( player );
            _rigidbody.angularVelocity = transform.forward * speed;
            if ( counter > speedUpCounter )
            {
                counter -= speedUpCounter;
                speed *= 1.5f;
            }
            
        }
    }
}

