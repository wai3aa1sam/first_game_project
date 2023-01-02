using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MainBoardController : GameController
{
    public bool hasPlayed = false;

    public bool hasRolled = false;
    
    public override void OnFirstButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context )
    {
        hasRolled = true;
        player.GetComponent<Player>().boardPlayerMovementHandler.HandleMoveForController();
    }

    public override void OnSecondButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context )
    {
        
    }

    public override void OnThirdButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context )
    {
        
    }

    public override void OnFourthButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context )
    {
        
    }
}
