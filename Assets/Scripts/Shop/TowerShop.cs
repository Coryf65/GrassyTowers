using Cory.TowerGame.Towers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Shop
{
    public class TowerShop : MonoBehaviour
    {
        [Header("Shop Settings")]
        [Tooltip("Amount of money the player has.")]
        [SerializeField] private int money;
        [SerializeField] private Transform buttonHolder;
        [SerializeField] private ShopButton towerShopButton;
        [SerializeField] private TowerData[] towerDatas = new TowerData[0];

        public event Action<int> OnMoneyChanged;

        public int Money => money;

        private void Start()
        {
            foreach (var towerData in towerDatas)
            {
                ShopButton towerShopButtonInstance = Instantiate(towerShopButton, buttonHolder);

                // init it
                towerShopButtonInstance.Initalise(towerData, this);
            }
        }
    }
}