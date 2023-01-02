using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Party.IceSurvive
{
    public class IceSurviveManager : Singleton<IceSurviveManager>
    {

        public int targetFood = 5;
        public int currentFood = 0;

        public bool testLoadScene = false;

        

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if ( testLoadScene )
            {
                GameManager.Instance.LoadBackToMainScene();
                testLoadScene = false;
            }
        }

        public bool CheckWin()
        {
            return currentFood >= targetFood;
        }

        public void AddFood()
        {
            currentFood++;
        }
    }
}
