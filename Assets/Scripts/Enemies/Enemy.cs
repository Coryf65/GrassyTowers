using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Enemies
{
    public class Enemy : MonoBehaviour
    {
        // reference our Scriptable Object
        [SerializeField] private EnemyData enemyData = null;

        private Node targetNode;
        private Vector3 currentDirection;
        private int health;
        private const float MinDistance = 0.1f;

        // getter
        public EnemyData EnemyData => enemyData;

        // Event
        public static event Action<EnemyData> OnKilled;

        private void Start()
        {
            health = enemyData.Health;
        }

        public void Update()
        {
            if (targetNode == null) { return; }

            MoveToTarget();

        }

        public void DealDamage(int damage)
        {
            // shorthand way of handling if else max damage
            health = Mathf.Max(health - damage, 0);

            if (health == 0)
            {
                OnKilled?.Invoke(enemyData);

                Destroy(gameObject);
            }
        }

        private void MoveToTarget()
        {
            // capping to our frame rate
            transform.Translate(currentDirection * enemyData.MovementSpeed * Time.deltaTime, Space.World);

            if ((transform.position - targetNode.transform.position).sqrMagnitude < MinDistance * MinDistance)
            {
                SetNode(targetNode.NextNode);
            }
        }

        public void SetNode(Node nextNode)
        {
            targetNode = nextNode;

            if (targetNode == null) { return; }
            // rotate
            currentDirection = (targetNode.transform.position - transform.position).normalized;

            if (currentDirection != Vector3.zero)
            {
                // face this direction
                transform.rotation = Quaternion.LookRotation(currentDirection);
            }
        }

    }
}
