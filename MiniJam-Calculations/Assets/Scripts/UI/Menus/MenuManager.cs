using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI.Menus
{
    /// <summary>
    /// This script manages the different menus in the game.
    /// </summary>
    public class MenuManager : MonoBehaviour
    {

        public enum CurrentMenu
        {
            MainMenu,
            SettingsMenu,
            CreditsMenu,
            PauseMenu,
        }
        public CurrentMenu currentMenu;

        void Awake()
        {
            currentMenu = CurrentMenu.MainMenu;
        }

    }
}
