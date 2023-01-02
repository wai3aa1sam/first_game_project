using System;
using System.Collections;
using System.Collections.Generic;
using Party.IceSurvive;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Party.IceSurvive
{
    public class IceSurviveAI : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Rotate,
            Move,
        }

        public State state = State.Idle;
        public float speed = 5.0f;
        public bool waitForWalk = true;
        public float walkTime = 3.0f;


        // Start is called before the first frame update
        void Start()
        {
            state = State.Rotate;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            if ( waitForWalk )
            {
                waitForWalk = false;
                StartCoroutine( WaitForTime( walkTime ) );
            }
            switch ( state )
            {
                case State.Rotate:
                    OnRotate();
                    break;
                case State.Move:
                    OnMove();
                    break;
                case State.Idle:
                    break;
                default:
                    break;
            }
        }

        void OnRotate()
        {
            Vector2 _randomPatrolDirection = Random.insideUnitCircle.normalized;
            Vector3 dir = new Vector3( _randomPatrolDirection.x, 0.0f, _randomPatrolDirection.y );
            transform.forward = dir;
            speed = Random.Range( 2.0f, 10.0f );
            state = State.Move;
            waitForWalk = true;
        }

        void OnMove()
        {
            transform.position += transform.forward * ( speed * Time.deltaTime );
        }

        IEnumerator WaitForTime( float time )
        {
            yield return new WaitForSeconds( time );
            state = State.Rotate;
        }

        private void OnCollisionEnter( Collision other )
        {
            if ( other.collider.CompareTag( "Player" ) )
            {
                var player = other.collider.GetComponent<Player>();
                player.iceTileHandler.OnFrozen();
            }
        }
    }
}
