using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public abstract class GameController : MonoBehaviour
{
    [Header( "Information" )]
    public int gameIndex = 0;
    public string actionScheme = "";

    public abstract void OnFirstButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context );
    public abstract void OnSecondButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context );
    public abstract void OnThirdButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context );
    public abstract void OnFourthButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context );
}
