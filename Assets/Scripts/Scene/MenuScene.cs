using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Main_Menu,
    Pause_Menu
}
 
[CreateAssetMenu(fileName = "NewMenuScene", menuName = "Scene Data/MenuScene")]
public class MenuScene : GameScene
{
    //Settings specific to menu only
    [Header("Menu specific")]
    public Type type;
}
