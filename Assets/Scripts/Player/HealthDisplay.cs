using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Cory.TowerGame.Player
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerHealthSystem healthSystem = null;
        [SerializeField] private TMP_Text healthText = null;

        private void OnEnable()
        {
            // if this gets called before the other script
            // then we read the data
            HandleHealthChanged(healthSystem.Health);

            healthSystem.OnHealthChanged += HandleHealthChanged;
        }

        private void OnDisable()
        {
            healthSystem.OnHealthChanged -= HandleHealthChanged;
        }

        private void HandleHealthChanged(int health)
        {
            healthText.text = health.ToString();
        }

    }
}