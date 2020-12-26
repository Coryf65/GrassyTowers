using Cory.TowerGame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Combat
{
    public class DealDamageOnHit : MonoBehaviour
    {
        [Header("Damage the collided Enemy")]
        [Tooltip("How much damage should this impact do? the other thing must be on the enemy Layer.")]
        [SerializeField] private int damage = 10;

        private void OnTriggerEnter(Collider other)
        {
            // if not an enemy then exit
            if (!other.TryGetComponent<Enemy>(out var enemy))
            {
                return;
            }
            enemy.DealDamage(damage);
        }
    }
}