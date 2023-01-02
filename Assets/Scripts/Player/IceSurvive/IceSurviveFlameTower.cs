using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSurviveFlameTower : MonoBehaviour
{
    [Range( 1, 10 )]public int probToFlame = 1;
    public GameObject flamePrefab;
    public Transform shootOrigin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FlameThrow()
    {
        int i = Random.Range( 1, 10 );
        if ( i <= probToFlame )
        {
            Instantiate( flamePrefab, shootOrigin.position, Quaternion.identity );
        }
    }
}
