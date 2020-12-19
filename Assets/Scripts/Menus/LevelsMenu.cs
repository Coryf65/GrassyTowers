using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cory.TowerGame.Menus
{
    public class LevelsMenu : MonoBehaviour
    {
        public void GoToLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
