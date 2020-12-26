using Cory.TowerGame.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cory.TowerGame.Waves
{
    public class WaveHandler : MonoBehaviour
    {
        [SerializeField] private int numberOfWaves = 1;
        [SerializeField] private int secondsBetweenWaves = 10;
        [SerializeField] private TMP_Text secondsRemainingText = null;
        [SerializeField] private WaveSpawner[] waveSpawners = new WaveSpawner[0];

        private int currentWave;
        private float secondsUntilNextWave;

        private readonly Dictionary<EnemyData, int> enemiesToKill = new Dictionary<EnemyData, int>();


        private void Update()
        {
            if (secondsUntilNextWave == 0f)
            {
                return;
            }
            else
            {
                secondsUntilNextWave -= Time.deltaTime;
            }

            if (secondsUntilNextWave <= 0f)
            {
                secondsUntilNextWave = 0f;
                secondsRemainingText.enabled = false;

                StartNextWave();
            }

            // update the ui
            secondsRemainingText.text = Mathf.Ceil(secondsUntilNextWave).ToString();
        }

        private void StartNextWave()
        {
            // go through each spawner
            foreach (var spawner in waveSpawners)
            {
                spawner.StartWave(currentWave);
            }
        }

        // Start spawning
        private void Start()
        {
            GetNextWave();
            ResetCountdown();
        }

        // Subscribe to our event
        private void OnEnable()
        {
            WaveDestination.OnEnemyReachedEnd += HandleEnemyKilled;
            Enemy.OnKilled += HandleEnemyKilled;
        }

        // UnSubscribe to our event
        private void OnDisable()
        {
            WaveDestination.OnEnemyReachedEnd -= HandleEnemyKilled;
            Enemy.OnKilled -= HandleEnemyKilled;
        }

        // Event Handler
        private void HandleEnemyKilled(EnemyData enemyData)
        {
            if (enemiesToKill.ContainsKey(enemyData))
            {
                // reduce the value by one
                enemiesToKill[enemyData]--;

                // check if this is the last one
                if (enemiesToKill[enemyData] == 0)
                {
                    enemiesToKill.Remove(enemyData);
                }
            }

            // check if all enemies are gone
            if (enemiesToKill.Count == 0)
            {
                // if so we go to the next wave
                currentWave++;

                // check if this is the Final Wave
                if (currentWave == numberOfWaves)
                {
                    // Player WINS!
                    return;
                }

                // Move onto the next Wave
                GetNextWave();

                ResetCountdown();
            }
        }

        private void ResetCountdown()
        {
            secondsUntilNextWave = secondsBetweenWaves;
            secondsRemainingText.enabled = true;
        }

        private void GetNextWave()
        {
            // loop through each spawner 
            foreach (var spawner in waveSpawners)
            {
                // loop through all our enemies in a wave
                foreach (var newEnemy in spawner.GetWave(currentWave))
                {    
                    if (enemiesToKill.ContainsKey(newEnemy.EnemyData))
                    {
                        enemiesToKill[newEnemy.EnemyData]++;
                    } else
                    {
                        // spawn them
                        enemiesToKill.Add(newEnemy.EnemyData, 1);
                    }
                }
            }
        }
    }
}