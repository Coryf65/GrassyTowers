using Cory.TowerGame.Enemies;
using Cory.TowerGame.Towers;
using UnityEngine;

namespace Cory.TowerGame.Targeting
{
    public abstract class TargetingSystem : MonoBehaviour
    {
        // cory
        [Header("Tower Connections")]
        [SerializeField] protected TowerData towerData = null;        
        [Space][Header("Tower Settings")]        
        [Tooltip("How often the Tower checks for enemies to shoot.")]
        [SerializeField] private float checkRate = 0.5f;
        [Tooltip("Which Layer this tower will look for an Enemy to shoot.")]
        [SerializeField] protected LayerMask layerMask = new LayerMask();

        private float timer;

        // allocating a set of memory and only use up to this much
        // setting the max amount of enemies to check for from a turret
        // abouts how many enemies that are on the screen at one time
        protected readonly Collider[] colliderBuffer = new Collider[50];

        public Enemy Target { get; protected set; }

        public void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                timer = checkRate;

                FindTarget();
            }

            if (Target == null) { return; }

            // aim at the target
            transform.LookAt(Target.transform);
        }

        // cannot make an instance of this script but any class inheriting this needs to implement
        // the abstract functions
        protected abstract void FindTarget();

    }
}