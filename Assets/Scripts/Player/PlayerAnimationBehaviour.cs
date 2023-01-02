using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimationBehaviour : MonoBehaviour
{
    [Header("Component References")]
    public Animator playerAnimator;

    //Animation String IDs
    private int playerMovementAnimationID;
    private int horizontal;
    private int vertical;
    private int attack;

    private int movementSpeed;
    //private int playerAttackAnimationID;

    public void SetupBehaviour()
    {
        SetupAnimationIDs();
    }

    void SetupAnimationIDs()
    {
        //playerMovementAnimationID = Animator.StringToHash("Speed");
        horizontal = Animator.StringToHash( "Horizontal" );
        vertical = Animator.StringToHash( "Vertical" );
        movementSpeed = Animator.StringToHash( "MovementSpeed" );
        attack = Animator.StringToHash( "Attack" );
        //playerAttackAnimationID = Animator.StringToHash("Attack");
    }

    public void UpdateMovementAnimation(float movementBlendValue)
    {
        playerAnimator.SetFloat(movementSpeed, movementBlendValue);
    }
    
    public void PlayAttackAnimation()
    {
        playerAnimator.SetTrigger(attack);
    }

    public void UpdateAnimatorValues( float horizontalMovement, float verticalMovement )
    {
        //Animation Snapping

        var snappedHorizontal = SnapHorizontal( horizontalMovement );
        var snappedVertical = SnapVertical( verticalMovement );

        playerAnimator.SetFloat( horizontal, snappedHorizontal, 0.1f, Time.deltaTime );
        playerAnimator.SetFloat( vertical, snappedVertical, 0.1f, Time.deltaTime );

    }

    private float SnapHorizontal( float horizontalMovement )
    {
        float snappedHorizontal;
        if ( horizontalMovement > 0 && horizontalMovement < 0.55f )
        {
            snappedHorizontal = 0.5f;
        }
        else if ( horizontalMovement > 0.55f )
        {
            snappedHorizontal = 1.0f;
        }
        else if ( horizontalMovement < 0.0f && horizontalMovement > -0.55f )
        {
            snappedHorizontal = -0.5f;
        }
        else if ( horizontalMovement < -0.55f )
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }

        return snappedHorizontal;
    }
    
    private float SnapVertical( float verticalMovement )
    {
        float snappedVertical;
        if ( verticalMovement > 0 && verticalMovement < 0.55f )
        {
            snappedVertical = 0.5f;
        }
        else if ( verticalMovement > 0.55f )
        {
            snappedVertical = 1.0f;
        }
        else if ( verticalMovement < 0.0f && verticalMovement > -0.55f )
        {
            snappedVertical = -0.5f;
        }
        else if ( verticalMovement < -0.55f )
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }

        return snappedVertical;
    }

    
}
