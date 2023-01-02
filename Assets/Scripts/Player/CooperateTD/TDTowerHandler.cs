using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerHandler : MonoBehaviour
{
    public GameObject[] towerPrefabs;
    public bool isBuildingMode = false;

    public int currentTowerIndex = 0;

    public Material buildingMaterial;
    public Vector3 buildingPosition;

    public Transform towerParent;

    private void Awake()
    {
        buildingPosition = transform.position + transform.forward;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buildingPosition = transform.position + transform.forward;
        Debug.DrawLine( transform.position, buildingPosition );
    }

    public void SpawnTower()
    {
        int x, y;
        CooperateTDManager.Instance.grid.GetXY( buildingPosition, out x, out y );
        
        Debug.Log( "x: " + x + " y: " + y );

        Vector3 pos = CooperateTDManager.Instance.grid.GetWorldCenterPosition( x, y ) ;

        var node = CooperateTDManager.Instance.grid.GetGridObject( x, y );
        if ( node != null && node.isWalkable )
        {
            var tower = Instantiate( towerPrefabs[ currentTowerIndex ], pos, Quaternion.identity );
            tower.transform.parent = towerParent;
            node.isWalkable = false;
        }
    }

    public void ChooseNextTower()
    {
        currentTowerIndex++;
        if ( currentTowerIndex > towerPrefabs.GetLength(0) - 1 )
        {
            currentTowerIndex = 0;
        }
    }
    
    public void ChoosePreviousTower()
    {
        currentTowerIndex--;
        if ( currentTowerIndex < 0 )
        {
            currentTowerIndex = towerPrefabs.GetLength(0) - 1;
        }
    }
}
