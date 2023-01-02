using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Party.PathRemember
{
    public class Board : MonoBehaviour
    {
        public List<int> tiles;

        public PathRememberManager pathRememberManager;

        private void Awake()
        {
            pathRememberManager = FindObjectOfType<PathRememberManager>();
        }

        public int GetCurrentNumberOfTiles()
        {
            return tiles.Count;
        }
    }
}

