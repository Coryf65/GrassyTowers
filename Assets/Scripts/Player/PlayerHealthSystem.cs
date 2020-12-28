using Cory.TowerGame.Enemies;
using Cory.TowerGame.Waves;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Player
{
    public class PlayerHealthSystem : MonoBehaviour
    {
        [Header("Destroy after duration elapsed")]
        [Tooltip("How long in seconds before this Gameobject will be destroyed.")]
        [SerializeField] private int health = 10;

        public event Action<int> OnHealthChanged;
        public static Action OnGameOver;

        // public getter
        public int Health => health;

        // Subsribing to the event
        private void OnEnable() => WaveDestination.OnEnemyReachedEnd += HandleEnemyReachedEnd;
        // Unsubscribing to the event
        private void OnDisable() => WaveDestination.OnEnemyReachedEnd -= HandleEnemyReachedEnd;

        private void HandleEnemyReachedEnd(EnemyData enemyData)
        {
            // deal damage to the player
            health = Mathf.Max(health - enemyData.Damage);

            OnHealthChanged?.Invoke(health);

            if (health > 0) { return; }
            // if health = 0 Game Over!
            OnGameOver?.Invoke();
        }
    }
}