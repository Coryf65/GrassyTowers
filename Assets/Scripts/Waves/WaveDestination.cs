using Cory.TowerGame.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Waves
{
    public class WaveDestination : MonoBehaviour
    {

        public static event Action<EnemyData> OnEnemyReachedEnd;

        private void OnTriggerEnter(Collider other)
        {
            // when a rigid body enters
            if (!other.TryGetComponent<Enemy>(out var enemy))
            {
                return;
            }
            
            // raise event ? = if null don't raise event
            // Invoke adds the params as the data supplied
            OnEnemyReachedEnd?.Invoke(enemy.EnemyData);

            Destroy(enemy.gameObject);
        }
    }
}