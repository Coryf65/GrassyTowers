using Cory.TowerGame.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Waves
{
    public class WaveSpawner : MonoBehaviour
    {
        // where to start
        [SerializeField] private Node startingNode = null;
        // which enemies to spawn and left over
        [SerializeField] private Wave[] waves = new Wave[0];

        private readonly Queue<Enemy> remainingSpawns = new Queue<Enemy>();

        private bool isSpawning;
        private float timeUntilNextSpawn;
        private Wave currentWave;
        private const float spawnRate = 0.5f;

        // getter
        public Enemy[] GetWave(int waveIndex) => waves[waveIndex].Enemies;

        private void Update()
        {
            if (!isSpawning) { return; }

            timeUntilNextSpawn -= Time.deltaTime;

            if (timeUntilNextSpawn <= 0f)
            {
                SpawnNextEnemy();
            }
        }

        public void StartWave(int waveIndex)
        {
            if (waveIndex >= waves.Length) { return; }

            currentWave = waves[waveIndex];

            foreach (Enemy enemy in currentWave.Enemies)
            {
                remainingSpawns.Enqueue(enemy);
            }
            SpawnNextEnemy();

            isSpawning = true;
        }

        private void SpawnNextEnemy()
        {
            if (remainingSpawns.Count == 0) { return; }

            // spawn an enemy towards our Z coordinate
            Enemy enemy = Instantiate(remainingSpawns.Dequeue(), transform.position, transform.rotation);

            enemy.SetNode(startingNode);

            if (remainingSpawns.Count == 0)
            {
                isSpawning = false;
                return;
            }

            timeUntilNextSpawn = spawnRate;
        }
    }
}