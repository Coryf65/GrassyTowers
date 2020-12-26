using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerData towerData = null;

        private TowerHolder towerHolder;

        public TowerData TowerData => towerData;

        public void Initialise(TowerHolder towerHolder)
        {
            this.towerHolder = towerHolder;
        } 
    }
}