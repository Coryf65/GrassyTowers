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
        [SerializeField] private Node startingNode = null;

        private Node targetNode;
        private Vector3 currentDirection;

        private const float MinDistance = 0.1f;


        public void Start()
        {
            targetNode = startingNode;
        }

        public void Update()
        {
            if (targetNode == null) { return; }

            MoveToTarget();

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

        private void SetNode(Node nextNode)
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
