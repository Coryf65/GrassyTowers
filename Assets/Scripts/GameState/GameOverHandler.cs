using Cory.TowerGame.Player;
using Cory.TowerGame.Waves;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cory.TowerGame.GameState
{
    public class GameOverHandler : MonoBehaviour
    {
        [SerializeField] private GameObject playerWinPanel = null;
        [SerializeField] private GameObject playerGameOverPanel = null;

        // go to the next Level
        private int nextLevelIndex;
        public const string HIGHESTLEVELINDEX = "HighestLevelIndex";

        private void OnEnable()
        {
            WaveHandler.OnPlayerWin += HandlerPlayerWin;
            PlayerHealthSystem.OnGameOver += HandlePlayerLose;
        }
        private void OnDisable()
        {
            WaveHandler.OnPlayerWin -= HandlerPlayerWin;
            PlayerHealthSystem.OnGameOver -= HandlePlayerLose;
        }

        private void HandlerPlayerWin()
        {
            playerWinPanel.SetActive(true);

            // save to player prefs, only to the new max level
            string activeSceneName = SceneManager.GetActiveScene().name;
            string levelIndex = activeSceneName.Split('_')[2]; // get the level number
            int levelIndexValue = int.Parse(levelIndex);
            
            // get our highset level and set if not lower 
            if (PlayerPrefs.GetInt(HIGHESTLEVELINDEX, 0) < levelIndexValue)
            {
                PlayerPrefs.SetInt(HIGHESTLEVELINDEX, levelIndexValue);
            }
            nextLevelIndex = levelIndexValue + 1; // try to go to the next level
        }

        private void HandlePlayerLose()
        {
            // Pause the game
            Time.timeScale = 0f;

            playerGameOverPanel.SetActive(true);
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // reset time
            Time.timeScale = 1f;
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("Scene_MainMenu");

            Time.timeScale = 1f;
        }

        public void GoToNextLevel()
        {
            // try to go to next level
            if (Application.CanStreamedLevelBeLoaded($"Scene_Level_{nextLevelIndex}"))
            {
                SceneManager.LoadScene($"Scene_Level_{nextLevelIndex}");
            } else
            {
                // could not load next level go to main menu
                SceneManager.LoadScene("Scene_MainMenu");
            }
        }

    }
}