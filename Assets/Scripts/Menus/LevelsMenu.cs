using Cory.TowerGame.GameState;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cory.TowerGame.Menus
{
    public class LevelsMenu : MonoBehaviour
    {

        private Button[] levelButtons;

        private void Start()
        {
            // get all the buttons where we attach this script
            levelButtons = GetComponentsInChildren<Button>();

            int highestLevelIndex = PlayerPrefs.GetInt(GameOverHandler.HIGHESTLEVELINDEX, 0);

            for (int i = 0; i < highestLevelIndex + 1; i++)
            {
                // only allow the player to click the unlocked buttons
                levelButtons[i].interactable = true;
            }
        }

        public void GoToLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
