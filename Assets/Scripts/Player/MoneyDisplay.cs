using Cory.TowerGame.Shop;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cory.TowerGame.Player
{
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] private TowerShop towerShop = null;
        [SerializeField] private TMP_Text moneyText = null;

        private void OnEnable()
        {
            // if this gets called before the other script
            // then we read the data
            HandleMoneyChanged(towerShop.Money);

            towerShop.OnMoneyChanged += HandleMoneyChanged;
        }

        private void OnDisable()
        {
            towerShop.OnMoneyChanged -= HandleMoneyChanged;
        }

        private void HandleMoneyChanged(int money)
        {
            moneyText.text = $"${money}";
        }
    }
}