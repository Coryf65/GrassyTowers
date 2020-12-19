using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerData towerData = null;

        public TowerData TowerData => towerData;
    }
}