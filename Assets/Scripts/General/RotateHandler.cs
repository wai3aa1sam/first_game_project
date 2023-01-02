using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.General
{
    public class RotateHandler : MonoBehaviour
    {
        private float rotationSpeed = 10.0f;
        public float itemRotationSpeed = 50.0f;
        public float itemBobSpeed = 2.0f;

        private Vector3 basePosition;

        // Start is called before the first frame update
        void Start()
        {
            basePosition = transform.position;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            transform.Rotate( Vector3.up, itemRotationSpeed * Time.deltaTime, Space.World );
            transform.position =
                basePosition + new Vector3( 0.0f, 0.25f * Mathf.Sin( Time.time * itemBobSpeed ), 0.0f );
        }

    }
}
