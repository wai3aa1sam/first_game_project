using System;
using System.Collections;
using Party.PathRemember;
using TMPro;
using UnityEngine;

namespace Party.PathRemember
{
    public class PathRememberManager : MonoBehaviour
    {
        public float waitTime = 10.0f;
        public bool isEnded = false;

        public int targetNumberOfTiles = 10;

        public bool isStartedGame = false;

        public bool isEnemyEnded = false;
        public bool isPlayerEnded = false;

        private Board board;
        private Block[] _blocks;

        public bool testLoadScene = false;
    
        private void Awake()
        {
            board = FindObjectOfType<Board>();
        }

        private void Start()
        {
            _blocks = FindObjectsOfType<Block>();
            StartCoroutine( StartGame() );
        }

        private void Update()
        {
            if ( testLoadScene )
            {
                GameManager.Instance.LoadBackToMainScene();
                testLoadScene = false;

            }
        }


        IEnumerator StartGame()
        {
            yield return new WaitForSeconds( waitTime );
            isStartedGame = true;
            foreach ( var block in _blocks )
            {
                StartCoroutine( block.StartTheGame() );
            }
        }

        public void CheckIsGameEnded()
        {
            if ( ( isEnemyEnded && isPlayerEnded ) || GameManager.Instance.CheckIsAllPlayerDead() )
            {
                Debug.Log( "End" );
                isEnded = true;
            }
            else
            {
                isEnded = false;
            }

            if ( isEnded )
            {

                // TODO: Scene Transition
            }
        }
        

        public bool CheckPlayerAndSetIsEnd( int number )
        {
            if (number >= targetNumberOfTiles )
            {
                isPlayerEnded = true;
                return isPlayerEnded;
            }
            return false;
        }
        
        public bool CheckEnemyAndSetIsEnd( int number )
        {
            if (number >= targetNumberOfTiles )
            {
                isEnemyEnded = true;
                return isEnemyEnded;
            }
            return false;
        }
    }
}

