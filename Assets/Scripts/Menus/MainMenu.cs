using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Cory.TowerGame.Menus
{
    public class MainMenu : MonoBehaviour
    {

        public void ExitGame()
        {
            // for quitting in the editor
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif

        }
    }
}