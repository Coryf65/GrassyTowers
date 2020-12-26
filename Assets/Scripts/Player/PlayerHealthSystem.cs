using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Player
{
    public class PlayerHealthSystem : MonoBehaviour
    {
        [Header("Destroy after duration elapsed")]
        [Tooltip("How long in seconds before this Gameobject will be destroyed.")]
        [SerializeField] private int totalHealth = 10;
    }
}