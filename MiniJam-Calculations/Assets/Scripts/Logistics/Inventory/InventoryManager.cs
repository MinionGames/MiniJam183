using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Logistics.Inventory
{
    /// <summary>
    /// Manages the inventory UI and interactions.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        // Singleton Instance
        public static InventoryManager instance;
        public static InventoryManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InventoryManager();
                return instance;
            }
        }

        // Variables
        [Header("Inventory Settings")]

        private Item[] inventoryItems; // List of Items in

        // -----Methods-----
        void Awake()
        {
            inventoryItems = new Item[5]; 
        }

        void Update()
        {

        }

        // Public Methods

    }
}
