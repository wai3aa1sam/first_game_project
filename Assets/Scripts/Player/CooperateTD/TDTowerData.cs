using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Tower" + "", menuName = "CooperateTD Data/Tower" )]
public class TDTowerData : ScriptableObject
{
    public float damage;
    public float attackTime;
    public float attackArea;

    public float slowDownFactor;
    
    public float cost;
    public float[] upgradeCost;
    public int currentLevel;
    public bool isSpreadTower;
    
    public GameObject towerProjectile;
}
