using System;
using System.Collections;
using System.Collections.Generic;
using Party.IceSurvive;
using UnityEngine;

namespace Party.IceSurvive
{
    public class IceFood : MonoBehaviour
    {
        public void OnIceFood()
        {
            gameObject.SetActive( true );
        }
        
        public void OffIceFood()
        {
            gameObject.SetActive( false );
        }
        
        private void OnTriggerEnter( Collider other )
        {
            if ( other.CompareTag( "Player" ) )
            {
                OffIceFood();
                IceSurviveManager.Instance.AddFood();
                IceSurviveManager.Instance.CheckWin();
                
            }
        }
    }

}