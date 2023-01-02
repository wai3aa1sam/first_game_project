using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDiceCheckZone : MonoBehaviour
{
    Vector3 diceVelocity;
    public BoardDice6 dice;

    // Update is called once per frame
    void FixedUpdate () {
        diceVelocity = BoardDice6.diceVelocity;
    }

    void OnTriggerStay(Collider col)
    {
        if ( col.CompareTag( "Dice6" ) && !dice.isRolled )
        {
            Debug.Log( "Collide with dice" );
            if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                switch (col.gameObject.name) {
                    case "Side1":
                        dice.diceNumber = 6;
                        dice.isRolled = true;

                        break;
                    case "Side2":
                        dice.diceNumber = 5;
                        dice.isRolled = true;

                        break;
                    case "Side3":
                        dice.diceNumber = 4;
                        dice.isRolled = true;

                        break;
                    case "Side4":
                        dice.diceNumber = 3;
                        dice.isRolled = true;

                        break;
                    case "Side5":
                        dice.diceNumber = 2;
                        dice.isRolled = true;

                        break;
                    case "Side6":
                        dice.diceNumber = 1;
                        dice.isRolled = true;

                        break;
                        
                }
            }
        }
        
    }
}
