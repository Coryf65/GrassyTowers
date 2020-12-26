using Cory.TowerGame.Enemies;
using Cory.TowerGame.Targeting;
using Cory.TowerGame.Towers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Combat
{
    public class LaserAttack : MonoBehaviour
    {
        [Header("Laser Settings")]
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private TowerData towerData = null;
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private LineRenderer lineRenderer = null;

        private float timer;

        private TargetingSystem targetingSystem;

        private void Start()
        {
            targetingSystem = GetComponent<TargetingSystem>();
        }

        private void Update()
        {
            Enemy target = targetingSystem.Target;

            if (target != null)
            {
                lineRenderer.positionCount = 2;

                lineRenderer.SetPositions(new Vector3[]
                {
                    spawnPoint.position,
                    target.transform.position
                });
            } else
            {
                lineRenderer.positionCount = 0;
            }

            timer -= Time.deltaTime;

            if (timer > 0f) { return; }

            timer = fireRate;

            if (target != null)
            {
                target.DealDamage(Mathf.CeilToInt(towerData.Dps * fireRate));
            }
        }
    }
}