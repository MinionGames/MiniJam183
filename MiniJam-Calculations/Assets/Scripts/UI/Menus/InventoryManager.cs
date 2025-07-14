using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI.Menus
{
    /// <summary>
    /// Manages the inventory UI and interactions.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        // Variables
        [Header("Inventory Settings")]



        private List<string> inventoryItems; // List of Items in

        // -----Methods-----
        void Start()
        {
            // Initialize inventory UI elements and load inventory data if necessary
            InitializeInventoryUI();
        }

        void Update()
        {

        }

        /// <summary>
        /// Sets up the inventory UI, including loading items and setting up buttons.
        /// </summary>
        private void InitializeInventoryUI()
        {
            // Code to set up the inventory UI, such as loading items, setting up buttons, etc.
            Debug.Log("Inventory UI Initialized");
        }

        // Public Methods

    }
}
