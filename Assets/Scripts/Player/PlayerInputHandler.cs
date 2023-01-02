using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    //Player ID
    [Header( "ID" )] [SerializeField] 
    private int playerID;
    public bool isReady = true;

    private float moveAmount;
    private bool isAttacking = false;
    
    [Header("Sub Behaviours")]
    public PlayerMovementBehaviour playerMovementBehaviour;
    public PlayerAnimationBehaviour playerAnimationBehaviour;
    
    [Header("Input Settings")]
    private PlayerInput playerInput;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    public GameController gameController;

    private GameObject _player;
    
    private void Awake()
    {
        SetupPlayer();
        isReady = true;
        GameManager.Instance.AddToPlayerInputHandlers( this );
        
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if ( !isReady )
        {
            Debug.Log( "Not Ready" );
            return;
        }
        UpdatePlayerMovement();
        UpdatePlayerAnimationMovement();
    }

    private void FixedUpdate()
    {
        if ( !isReady )
        {
            return;
        }
        playerMovementBehaviour.Handle();
    }

    public void SetupPlayer()
    {
        playerInput = GetComponent<PlayerInput>();
        GameManager.Instance.ActivePlayer( playerInput.playerIndex );

        var movers = FindObjectsOfType<PlayerMovementBehaviour>();
        playerID = playerInput.playerIndex;
        playerMovementBehaviour = movers.FirstOrDefault(m => m.GetPlayerIndex() == playerID);

        _player = playerMovementBehaviour.gameObject;
        _player.GetComponent<Player>().playerInputHandler = this;

        playerAnimationBehaviour = _player.GetComponentInChildren<PlayerAnimationBehaviour>();

        playerAnimationBehaviour.SetupBehaviour();

        isReady = true;
        playerInput.ActivateInput();
    }
    
    void UpdatePlayerMovement()
    {
        if ( isAttacking )
        {
            return;
        }
        if ( moveAmount > 0.0f && moveAmount < 0.5f )
        {
            playerMovementBehaviour.UpdateMovementSpeed( 0.5f );
        }
        else if ( moveAmount >= 0.5f && moveAmount <= 1.0f )
        {
            playerMovementBehaviour.UpdateMovementSpeed( 1.0f );
        }
    }
    void UpdatePlayerAnimationMovement()
    {
        moveAmount = Mathf.Clamp01( Mathf.Abs( movementInput.x ) + Mathf.Abs( movementInput.y ) );
        playerAnimationBehaviour.UpdateMovementAnimation( moveAmount );
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }

    public void UpdatePlayerAnimationAttack()
    {
        isAttacking = true;
        //playerMovementBehaviour.UpdateMovementSpeed( 0.0f );
        playerAnimationBehaviour.PlayAttackAnimation();
        //StartCoroutine( WaitTimeForAttack( 0.8f ) );
    }

    public void DisablePlayerInputHandler()
    {
        playerInput.DeactivateInput();
    }
    
    public void EnablePlayerInputHandler()
    {
        playerInput.ActivateInput();
    }

    private IEnumerator WaitTimeForAttack( float time )
    {
        yield return new WaitForSeconds( time );
        isAttacking = false;
    }

    public int GetPlayerID()
    {
        return playerID;
    }
    
    public void OnMove(CallbackContext context)
    {
        if ( playerMovementBehaviour != null )
        {
            var input = context.ReadValue<Vector2>();
            playerMovementBehaviour.SetInputVector( input );
            movementInput = input;
        }
        
    }

#region Control

    public void OnFirstButtonPressed(CallbackContext context)
    {
        if ( _player != null )
        {
            gameController.OnFirstButton( this, _player, context );
        }
    }
    
    public void OnSecondButtonPressed(CallbackContext context)
    {
        if ( _player != null )
        {
            gameController.OnSecondButton( this, _player, context );
        }
    }
    
    public void OnThirdButtonPressed(CallbackContext context)
    {
        if ( _player != null )
        {
            gameController.OnThirdButton( this, _player, context );
        }
    }
    
    public void OnFourthButtonPressed(CallbackContext context)
    {
        if ( _player != null )
        {
            gameController.OnFourthButton( this, _player, context );
        }
    }

#endregion
    
}