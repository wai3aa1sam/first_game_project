using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    private Transform[] childObjects;
    public List<Transform> childNodeList = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        FillNode();

        for ( int i = 0; i < childNodeList.Count; i++ )
        {
            Vector3 currentPos = childNodeList[ i ].position;
            if ( i > 0 )
            {
                Vector3 prevPos = childNodeList[ i - 1 ].position;
                Gizmos.DrawLine( prevPos, currentPos );
            }
        }
    }

    void FillNode()
    {
        childNodeList.Clear();

        childObjects = GetComponentsInChildren<Transform>();

        foreach ( var child in childObjects )
        {
            if ( child != this.transform )
            {
                childNodeList.Add(child);
            }
        }
    }
}
