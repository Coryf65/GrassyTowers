using Cory.TowerGame.Enemies;
using Cory.TowerGame.Targeting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Combat
{
    public class ProjectileAttack : MonoBehaviour
    {
        [Header("Combat Settings")]
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private Rigidbody projectilePrefab = null;
        [SerializeField] private float launchForce = 5f;

        private float timer;
        private TargetingSystem targetingSystem;

        private void Start() => targetingSystem = GetComponent<TargetingSystem>();

        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer > 0f) { return; }

            timer = fireRate;
            Enemy target = targetingSystem.Target;

            if (target == null) { return; }

            // we found an enemy and its time to fire
            Rigidbody projectileInstance = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            // Add a force in the direction, blue axis
            projectileInstance.AddForce(spawnPoint.forward * launchForce, ForceMode.VelocityChange);
        }

    }
}