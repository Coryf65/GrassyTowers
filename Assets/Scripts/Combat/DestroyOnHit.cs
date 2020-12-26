using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Combat
{
    public class DestroyOnHit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}