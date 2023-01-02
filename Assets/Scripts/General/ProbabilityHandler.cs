using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.General
{
    public class ProbabilityHandler : MonoBehaviour
    {
        public float percentage = 30f; 
        
        public bool Roll( float percenatageToHappen )
        {
            percentage = percenatageToHappen;
            var actual = 1 - percentage / 100;
            return Random.value > actual;
        }
        
    }
}
