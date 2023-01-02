using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class BoardPlayerMovementHandler: MonoBehaviour
{
    public Route currentRoute;
    
    private int routePosition;

    private Transform parent;

    public int steps;

    public float speed = 2.0f;

    private bool isMoving;

    private void Awake()
    {
        parent = transform.parent.parent;
    }

    private void Update()
    {
        
    }

    public void HandleMoveForController()
    {
        StartCoroutine( HandleMove() );
    }

    public IEnumerator HandleMove()
    {
        MainBoardManager.Instance.dice6.RollDice();
        while ( WaitForDice() )
        {
            yield return null;
        }
        
        yield return new WaitForSeconds( 3.5f );
        MainBoardManager.Instance.dice6.isRolled = false;
        steps = MainBoardManager.Instance.dice6.diceNumber;
        
        Debug.Log( steps );

        StartCoroutine( Move() );
    }

    IEnumerator Move()
    {
        if ( isMoving )
        {
            yield break;
        }

        isMoving = true;

        while ( steps > 0 )
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;

            Vector3 nextPos = currentRoute.childNodeList[ routePosition ].position;
            parent.LookAt( nextPos );
            while ( MoveToNextNode( nextPos ) )
            {
                yield return null;
            }
            
            yield return new WaitForSeconds( 0.1f );
            steps--;
        }
        
        isMoving = false;
    }

    bool MoveToNextNode( Vector3 goal )
    {
        return goal != ( parent.position = Vector3.MoveTowards( parent.position, goal, speed * Time.deltaTime ) );
    }

    bool WaitForDice()
    {
        return !MainBoardManager.Instance.dice6.isRolled;
    }
}
