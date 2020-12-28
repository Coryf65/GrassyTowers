using Cory.TowerGame.Shop;
using Cory.TowerGame.Towers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Cory.TowerGame.Player
{
    public class TowerToolTip_Display : MonoBehaviour, IPointerExitHandler
    {
        [SerializeField] private TowerShop towerShop = null;
        [SerializeField] private GameObject tooltipDisplay = null;
        [SerializeField] private Image towerIconImage = null;
        [SerializeField] private TMP_Text towerNameText = null;
        [SerializeField] private TMP_Text towerPriceText = null;
        [SerializeField] private TMP_Text towerDPSText = null;
        [SerializeField] private TMP_Text towerRangeText = null;

        private Camera mainCamera;
        private TowerHolder towerHolder;

        private void Start() => mainCamera = Camera.main;

        private void OnEnable() => Tower.OnTowerSelected += HandleTowerSelected;
        private void OnDisable() => Tower.OnTowerSelected -= HandleTowerSelected;

        private void HandleTowerSelected(TowerHolder towerHolder)
        {
            // set the tooltip at the same position at the world, the UI and gameWorld are in different parts
            tooltipDisplay.transform.position = mainCamera.WorldToScreenPoint(towerHolder.Tower.transform.position);

            // Setting up the UI
            towerIconImage.sprite = towerHolder.Tower.TowerData.Icon;
            towerNameText.text = towerHolder.Tower.TowerData.Name;
            towerPriceText.text = $"${towerHolder.Tower.TowerData.Price}";
            towerDPSText.text = $"DPS: {towerHolder.Tower.TowerData.Dps}";
            towerRangeText.text = $"Range: {towerHolder.Tower.TowerData.Range}";

            this.towerHolder = towerHolder;

            tooltipDisplay.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltipDisplay.SetActive(false);
        }

        public void Sell()
        {
            towerShop.Sell(towerHolder.Tower.TowerData);

            towerHolder.RemoveTower();

            tooltipDisplay.SetActive(false);
        }
    }
}