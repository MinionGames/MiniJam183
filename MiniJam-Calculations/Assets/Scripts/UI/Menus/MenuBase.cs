using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

namespace Game.UI.Menus
{
    /// <summary>
    /// This script serves as a base class for all menu scripts in the game.
    /// It can be extended by other menu scripts to provide common functionality.
    /// </summary
    public class MenuBase : MonoBehaviour
    {
        /// <summary>
        /// This method can be overridden by derived classes to perform actions when the menu is opened.
        /// </summary>
        public virtual void OnMenuOpen() {}

        /// <summary>
        /// This method can be overridden by derived classes to perform actions when the menu is closed.
        /// </summary>
        public virtual void OnMenuClose() {}
        
    }
}
