using System;
using System.Collections;
using System.Collections.Generic;
using Party.IceSurvive;
using UnityEngine;

public class Player : MonoBehaviour, IComparable
{
    public int index = 0;
    
    [Header( "No Need to Assign" )]
    public PlayerInputHandler playerInputHandler;

    [Header( "Need to Assign" )] 
    public BoardPlayerMovementHandler boardPlayerMovementHandler;
    public TDTowerHandler tdTowerHandler;
    public IceTileHandler iceTileHandler;
    public TileHandler tileHandler;
    public HealthSystem healthSystem;

    private void Awake()
    {
        //index = gameObject.GetComponentInChildren<>()
        playerInputHandler = GetComponentInChildren<PlayerInputHandler>();
    }

    public int CompareTo( object obj )
    {
        if ( obj is Player )
        {
            return  this.index.CompareTo( ( obj as Player ).index );
        }
        throw new ArgumentException ("object is not Player" );
    }
}
