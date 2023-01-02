using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    
    [Header("Movement Settings")]
    public float movementSpeed = 3.0f;
    public float rotationSpeed = 15f;
    public float ActualMovementSpeed;
    

    [SerializeField]
    private int playerIndex = 0;

    private Rigidbody _playerRigidbody;

    private Vector3 movementDirection;
    private Vector2 inputVector;
    
    
    [SerializeField] private Transform _cameraTransform;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        //_cameraTransform = Camera.main.transform;
        
        ActualMovementSpeed = movementSpeed;
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }
    public void Handle()
    {
        HandleMovement();
        HandleRotation();
    }
    
    public void UpdateMovementSpeed(float newMovementMultiplier)
    {
        var temp = movementSpeed * newMovementMultiplier;
        ActualMovementSpeed = temp;
    }

    void HandleMovement()
    {
        movementDirection = _cameraTransform.forward * inputVector.y;
        
        movementDirection += _cameraTransform.right * inputVector.x;
        //Debug.Log( "forward:　" +_cameraTransform.forward );
//
        //Debug.Log( "right:　"+_cameraTransform.right );

        movementDirection.Normalize();
        
        //Debug.Log( movementDirection );

        movementDirection.y = 0;
        movementDirection *= ActualMovementSpeed;

        Vector3 movementVelocity = movementDirection;
        _playerRigidbody.velocity = movementVelocity;
    }
    
    void HandleRotation()
    {
        
         Vector3 targetDirection = Vector3.zero;
         targetDirection = _cameraTransform.forward * inputVector.y;
         targetDirection += _cameraTransform.right * inputVector.x;
         targetDirection.Normalize();
         
         targetDirection.y = 0;
         
         if ( targetDirection == Vector3.zero )
         {
             targetDirection = transform.forward;
         }
         
         Quaternion targetRotation = Quaternion.LookRotation( targetDirection );
         Quaternion playerRotation = Quaternion.Slerp( transform.rotation, targetRotation, rotationSpeed * Time.deltaTime );

         transform.rotation = playerRotation;
         //_playerRigidbody.MoveRotation( playerRotation );

    }
}
