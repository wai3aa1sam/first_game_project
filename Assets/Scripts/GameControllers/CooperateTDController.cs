using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CooperateTDController : GameController
{
    public bool hasPlayed = false;
    
    public override void OnFirstButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context )
    {
        playerInputHandler.UpdatePlayerAnimationAttack();
    }

    public override void OnSecondButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context )
    {
        player.GetComponent<Player>().tdTowerHandler.SpawnTower();
    }

    public override void OnThirdButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context )
    {
        player.GetComponent<Player>().tdTowerHandler.ChoosePreviousTower();
    }

    public override void OnFourthButton( PlayerInputHandler playerInputHandler, GameObject player, CallbackContext context )
    {
        player.GetComponent<Player>().tdTowerHandler.ChooseNextTower();
    }
}
