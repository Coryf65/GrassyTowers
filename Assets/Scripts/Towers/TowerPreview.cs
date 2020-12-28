using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.TowerGame.Towers
{
    public class TowerPreview : MonoBehaviour
    {
        [SerializeField] private GameObject visuals = null;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;

            MoveToCursor();

            visuals.SetActive(true);
        }

        private void Update()
        {
            MoveToCursor();
        }

        private void MoveToCursor()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // the ray hits the plane
            Plane plane = new Plane(Vector3.up, Vector3.zero); // this is how the preview moves

            if (!plane.Raycast(ray, out float distance)) { return; }

            transform.position = ray.GetPoint(distance); // get the point
        }
    }
}