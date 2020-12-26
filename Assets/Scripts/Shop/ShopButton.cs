﻿using Cory.TowerGame.Towers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Cory.TowerGame.Shop
{
    public class ShopButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Shop Button")]
        [Tooltip("The Text to display the price.")]
        [SerializeField] private TMP_Text priceText = null;
        [Tooltip("The Icon Image for the Tower.")]
        [SerializeField] private Image towerIconImage = null;

        private bool isDragging;
        private Camera mainCamera;
        private TowerData towerData;
        private TowerShop towerShop;

        private void Start() => mainCamera = Camera.main;

        public void Initalise(TowerData towerData, TowerShop towerShop)
        {
            priceText.text = $"${towerData.Price}";
            towerIconImage.sprite = towerData.Icon;

            // cache these
            this.towerData = towerData;
            this.towerShop = towerShop;


        }

        // mouse down event
        public void OnPointerDown(PointerEventData eventData)
        {
            isDragging = true;
        }

        // mouse off event
        public void OnPointerUp(PointerEventData eventData)
        {
            if (!isDragging) { return; }

            // otherwise do a raycast
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<TowerHolder>(out var towerHolder))
                {
                    // set this to be our tower
                    if (towerHolder.Tower == null)
                    {
                        towerHolder.SetTower(towerData);

                        // Buy tower, spend monies
                    }
                }
            }
            isDragging = false;
        }
    }
}