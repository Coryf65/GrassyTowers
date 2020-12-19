using Cory.TowerGame.Enemies;
using System;
using UnityEngine;

namespace Cory.TowerGame.Waves
{
    // Making this class available
    [Serializable]
    public class Wave
    {
        [SerializeField] private Enemy[] enemies = new Enemy[0];

        public Enemy[] Enemies => enemies;
    }
}