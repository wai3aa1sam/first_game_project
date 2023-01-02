using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Party.PathRemember
{
    public class Tile : MonoBehaviour
    {
        //private int _currentNumberPlayer = 0;
        //private GameObject[] _players = new GameObject[Constant.MAXNUMBEROFPLAYERS];
        private Board board;
        static int tileIndex = 0;

        private int id;
        
        public float damage = 50.0f;

        private static bool isEnded = false;

        private void Awake()
        {
            board = FindObjectOfType<Board>();
            id = tileIndex;
            tileIndex++;
        }

        private void OnTriggerEnter( Collider other )
        {
            if ( isEnded )
            {
                return;
            }
            if ( other.CompareTag( "Enemy" ) )
            {
                int n = this.id;
                board.tiles.Add( n );
                var enemy = other.GetComponent<PathRememberAI>();
                enemy.currentIndex++;
                enemy.CheckIsEnded( board.pathRememberManager.CheckEnemyAndSetIsEnd( enemy.currentIndex ) ); 
                Debug.Log( "Enemy found!" );

                return;
            }
            
            if ( other.CompareTag( "Player" ) )
            {
                Player player = other.GetComponent<Player>();
                if ( player == null )
                {
                    Debug.Log( "No player found!" );
                    return;
                }
                if ( board.tiles[player.tileHandler.currentTileIndex] == this.id /*&& player.tileHandler.safeToLeave*/ )
                {
                    player.tileHandler.safeToLeave = false;
                    player.tileHandler.currentTileIndex++;
                    isEnded = board.pathRememberManager.CheckPlayerAndSetIsEnd( player.tileHandler.currentTileIndex );
                    Debug.Log( isEnded );

                    board.pathRememberManager.CheckIsGameEnded();
                    Debug.Log( "Enter, Correct!" );
                }
                else
                {
                    DamagePlayer( player, damage );
                    Debug.Log( "Enter, InCorrect!" );
                }
            }
        }

        private void OnTriggerExit( Collider other )
        {
            if ( isEnded )
            {
                return;
            }
            if ( other.CompareTag( "Player" ) )
            {
                Player player = other.GetComponent<Player>();
                if ( player == null )
                {
                    Debug.Log( "No player found!" );
                    return;
                }
                if ( !player.tileHandler.safeToLeave )
                {
                    DamagePlayer( player, damage );
                }
                player.tileHandler.safeToLeave = true;
                Debug.Log( "Exit: "+ player.tileHandler.currentTileIndex );

            }
        }

        public void DamagePlayer( Player player, float damage )
        {
            if ( player == null )
            {
                Debug.Log( "No player found!" );
            }
            
            player.healthSystem.TakeDamage( damage );
        }
    }
}
