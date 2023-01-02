using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePortal : MonoBehaviour
{
    private void OnTriggerEnter( Collider other )
    {
        if ( other.CompareTag( "Player" ) )
        {
            GameManager.Instance.LoadNextGame();
        }
    }
}
