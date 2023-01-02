using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Party.PathRemember
{
    public class PathRememberAI : MonoBehaviour
    {
        enum State
        {
            Idle,
            Rotate,
            Move,
            Detect,
        }

        public int currentIndex = 0;
        public GameObject EFXPrefab;

        [Header( "Scene" )] 
        public GameObject scenePortal;
        
        [Header("Movement Settings")]
        public float movementSpeed = 3.0f;
        public float rotationSpeed = 15.0f;
        public float ActualMovementSpeed;
        
        private Rigidbody _enemyRigidbody;

        private Animator _enemyAnimator;

        [SerializeField] private float nearByDistance = 10.0f;
        [SerializeField] private float lookAtFactor = 0.9f;

        // Behaviour
        private State state;
        
        // RayCast
        //[SerializeField]private int rayDistanceRatio = 5;
        [SerializeField]private float rayLength = 50f;
        
        private Vector3 movementDirection = Vector3.zero;
        private Vector2 _rawInput = Vector2.zero;
        private Transform _cameraTransform;
        private Tile tempTile;

        private bool isEnded = false;

        
        // Start is called before the first frame update
        void Start()
        {
            _enemyRigidbody = GetComponent<Rigidbody>();

            _cameraTransform = Camera.main.transform;
            ActualMovementSpeed = movementSpeed;
            
            
            
            DetectTile();
        }
        private void FixedUpdate()
        {
            switch ( state )
            {
                case State.Rotate:
                    StartCoroutine( RotateTo( tempTile ) );
                    break;
                case State.Move:
                    StartCoroutine( MoveTo( tempTile ) );
                    break;
                case State.Detect:
                    DetectTile();
                    break;
                default:
                    break;
            }
        }

        public void CheckIsEnded( bool condition )
        {
            isEnded = condition;

            if ( isEnded )
            {
                var efx = Instantiate( EFXPrefab, transform.position, Quaternion.identity );
                
                var portal = Instantiate( scenePortal, transform.position, Quaternion.identity );
                

                gameObject.SetActive( false );
            }
            

        }

        private void DetectTile()
        {
            state = State.Idle;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayLength, Color.yellow, 1.0f);
            //Debug.DrawRay(transform.position, -transform.TransformDirection(Vector3.forward) * rayLength, Color.yellow, 1.0f);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * rayLength, Color.yellow, 1.0f);
            //Debug.DrawRay(transform.position, -transform.TransformDirection(Vector3.right) * rayLength, Color.yellow, 1.0f);
            
            StartCoroutine( RayCastToTiles() );
        }

        private IEnumerator RayCastToTiles()
        {
            RaycastHit hit;
            int randomDirection = Random.Range( 0, 4 );
            Vector3 direction = RayToWhichDirection( randomDirection );

            bool isHiitted = false;
            do
            {
                if ( Physics.Raycast( transform.position, direction, out hit, rayLength ) )
                {
                    isHiitted = hit.collider.CompareTag( "Tile" );
                    if ( isHiitted )
                    {
                        tempTile = hit.collider.GetComponent<Tile>();
                        isHiitted = true;
                        yield return new WaitForSeconds( 0.5f );
                        state = State.Rotate;
                    }
                    else
                    {
                        randomDirection = Random.Range( 0, 4 );
                        direction = RayToWhichDirection( randomDirection );
                    }
                }
                else
                {
                    randomDirection = Random.Range( 0, 4 );
                    direction = RayToWhichDirection( randomDirection );
                }

            } while ( !isHiitted );
        }
        
        private Vector3 RayToWhichDirection( int index )
        {
            switch ( index )
            {
                case 0:
                    return transform.TransformDirection( Vector3.forward );
                case 1:
                    return -transform.TransformDirection( Vector3.forward );
                case 2:
                    return transform.TransformDirection( Vector3.right );
                case 3:
                    return -transform.TransformDirection( Vector3.right );
                default:
                    return Vector3.zero;
            }
        }

        //void OnDrawGizmosSelected()
        //{
        //    // Draws a 5 unit long red line in front of the object
        //    Gizmos.color = Color.red;
        //    Vector3 fowardDirection = transform.TransformDirection(Vector3.forward) * rayDistanceRatio;
        //    Vector3 rightDirection = transform.TransformDirection(Vector3.right) * rayDistanceRatio;
        //    Gizmos.DrawRay(transform.position, fowardDirection);
        //    Gizmos.DrawRay(transform.position, -fowardDirection);
        //    Gizmos.DrawRay(transform.position, rightDirection);
        //    Gizmos.DrawRay(transform.position, -rightDirection);
//
        //}

        private bool isArrived()
        {
            return ( tempTile.transform.position - transform.position ).sqrMagnitude <= nearByDistance;
        }

        private bool isRotated()
        {
            Vector3 dirFromAtoB = (tempTile.transform.position - transform.position).normalized;
            float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);
            
            return ( dotProd > lookAtFactor );
        }

        private IEnumerator MoveTo( Tile tile )
        {
            if ( !isArrived() )
            {
                state = State.Move;
            }
            else
            {
                state = State.Idle;
                yield return new WaitForSeconds( 0.2f );
                state = State.Detect;
            }

            if ( !tempTile )
            {
                yield break;
            }
            movementDirection = tile.transform.position - transform.position;
            movementDirection.Normalize();
            movementDirection.y = 0;
            movementDirection *= ActualMovementSpeed * Time.fixedDeltaTime;
            
            _enemyRigidbody.MovePosition( transform.position + movementDirection );
        }

        private IEnumerator RotateTo( Tile tile )
        {
            if ( !isRotated() )
            {
                state = State.Rotate;
            }
            else
            {
                state = State.Idle;
                yield return new WaitForSeconds( 0.2f );
                state = State.Move;
            }
            if ( !tempTile )
            {
                yield break;
            }
            Vector3 targetDirection = tile.transform.position - transform.position;
            targetDirection.Normalize();
            targetDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation( targetDirection );
            Quaternion enemyRotation = Quaternion.Slerp( transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime );
            
            _enemyRigidbody.MoveRotation( enemyRotation );
        }
    }
}

