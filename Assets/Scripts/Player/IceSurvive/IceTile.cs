using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Game.General;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;

namespace Party.IceSurvive
{
    public class IceTile : MonoBehaviour
    {
        public enum State
        {
            Trap = 0,
            Food,
            Idle,
            Roll
        }

        private IceBoard board;
        static int tileIndex = 0;
        
        private int id;
        private Vector3 _trapPosition;
        private Vector3 _foodPosition;
        private IceTrap _iceTrap;
        private IceFood _iceFood;
        private bool isWaitingForRoll = false;
        private State state;

        public GameObject trapPrefab;
        public GameObject foodPrefab;

        public float timeForNextRoll = 3.0f;

        public bool onTrap = false;

        private void Awake()
        {
            board = FindObjectOfType<IceBoard>();
            id = tileIndex;
            tileIndex++;

            _trapPosition = new Vector3( transform.position.x, -0.5f, transform.position.z );
            _foodPosition = new Vector3( transform.position.x, 0.3f, transform.position.z );
        }

        // Start is called before the first frame update
        void Start()
        {
            SpawnTrap();
            SpawnFood();
            state = State.Roll;
        }

        // Update is called once per frame
        void Update()
        {
            if ( isWaitingForRoll )
            {
                isWaitingForRoll = false;
                StartCoroutine( WaitForRoll( timeForNextRoll ) );
            }

            if ( state == State.Roll )
            {
                Roll();
            }
        }

        void Roll()
        {
            state = (State)Random.Range( 0, 3 );
            isWaitingForRoll = true;
            switch ( state )
            {
                case State.Trap:
                    if ( GameManager.Instance.probabilityHandler.Roll( 30 ) )
                    {
                        ActiveTrap();
                    }
                    state = State.Trap;
                    break;
                case State.Food:
                    if ( GameManager.Instance.probabilityHandler.Roll( 10 ) )
                    {
                        ActiveFood();
                    }
                    state = State.Food;
                    break;
                case State.Idle:
                    state = State.Idle;
                    break;
            }
            
        }
        IEnumerator WaitForRoll( float time )
        {
            yield return new WaitForSeconds( time );
            isWaitingForRoll = false;
            state = State.Roll;
        }
        

        void SpawnTrap()
        {
            var trap = Instantiate( trapPrefab, _trapPosition, Quaternion.identity );
            trap.transform.parent = transform;
            _iceTrap = trap.GetComponent<IceTrap>();
        }

        void ActiveTrap()
        {
            _iceTrap.SetOnTrap();
        }

        void SpawnFood()
        {
            var food = Instantiate( foodPrefab, _foodPosition, Quaternion.identity );
            food.transform.parent = transform;
            _iceFood = food.GetComponent<IceFood>();
            _iceFood.OffIceFood();
        }

        void ActiveFood()
        {
            _iceFood.OnIceFood();
        }
    }
}
