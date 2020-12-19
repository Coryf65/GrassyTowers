using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Enemies
{
    // This creates a new right click context menu
    [CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemies / Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private int health = 50;
        [SerializeField] private int moneyReward = 20;
        [SerializeField] private float movementSpeed = 5f;

        // getters
        public int Damage => damage;
        public int Health => health;
        public int MoneyReward => moneyReward;
        public float MovementSpeed => movementSpeed;



    }
}