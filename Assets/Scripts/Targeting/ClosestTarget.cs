using Cory.TowerGame.Enemies;
using Cory.TowerGame.Towers;
using UnityEngine;

namespace Cory.TowerGame.Targeting
{
    public class ClosestTarget : TargetingSystem
    {
        // inherited Target, with our implementation
        protected override void FindTarget()
        {
            // we are telling this the amount of mem to use
            // does a Sphere check at the range and only colliding with our layer we set
            int colliderCount = Physics.OverlapSphereNonAlloc(transform.position, towerData.Range, colliderBuffer, layerMask);

            Enemy closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < colliderCount; i++)
            {
                // checking the distance between towers and enemies
                float distanceSquared = (colliderBuffer[i].transform.position - transform.position).sqrMagnitude;

                if (distanceSquared < closestDistance * closestDistance)
                {
                    // make sure this is an enemy, if so pass out the Enemy Component
                    if (colliderBuffer[i].TryGetComponent<Enemy>(out var enemy))
                    {
                        closestDistance = distanceSquared;
                        closestEnemy = enemy;
                    }
                }
            }

            Target = closestEnemy;
        }
    }
}