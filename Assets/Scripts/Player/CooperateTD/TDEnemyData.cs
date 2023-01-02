using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Enemy", menuName = "CooperateTD Data/Enemy" )]
public class TDEnemyData : ScriptableObject
{
    public float health;
    public float walkSpeed;

    public int money;

    public int damage;
}
