using Cory.TowerGame.Enemies;
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

        private void OnEnable()
        {
            Enemy.OnKilled += HandleEnemyKilled;
        }

        private void OnDisable()
        {
            Enemy.OnKilled -= HandleEnemyKilled;
        }

        // Get money when an enemy is killed
        private void HandleEnemyKilled(EnemyData enemyData)
        {
            money += enemyData.MoneyReward;

            OnMoneyChanged?.Invoke(money);
        }

        // Player is purchasing a Tower
        public void Purchase(int amountToSpend)
        {
            money -= amountToSpend;

            OnMoneyChanged?.Invoke(money);
        }

        public void Sell(TowerData towerData)
        {
            money += towerData.Price;

            OnMoneyChanged?.Invoke(money);
        }
    }
}