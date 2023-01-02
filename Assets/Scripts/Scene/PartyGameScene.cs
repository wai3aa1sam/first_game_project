using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPartyGameScene", menuName = "Scene Data/PartyGameScene")]
public class PartyGameScene : GameScene
{
    //Settings specific to level only
    [Header( "Level specific" )] 
    public int index = 0;

    public bool hasPlayed = false;

    public GameObject gameController;
}
