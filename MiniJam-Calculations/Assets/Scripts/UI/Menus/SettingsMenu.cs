using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Menus
{
    /// <summary>
    /// This script controls the Settings menu of the game.
    /// </summary>
    public class SettingsMenu : MenuBase
    {
        


        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
