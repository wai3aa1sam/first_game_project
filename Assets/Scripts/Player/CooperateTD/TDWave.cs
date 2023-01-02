using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Wave", menuName = "CooperateTD Data/Wave" )]
public class TDWave : ScriptableObject
{
    public int enemyNumber = 0;
    public int money = 100;

    public GameObject enemyPrefab;
}
