using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Combat
{
    public class DestroyAfterDuration : MonoBehaviour
    {
        [Header("Destroy after duration elapsed")]
        [Tooltip("How long in seconds before this Gameobject will be destroyed.")]
        [SerializeField] private float duration = 10f;

        private void Start()
        {
            Destroy(gameObject, duration);
        }
    }
}