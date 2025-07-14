using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Logistics.Inventory
{
    /// <summary>
    /// Represents a generic item in the game.
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
    [System.Serializable]
    public class Item : ScriptableObject
    {
        // Variables
        [Header("Item Properties")]
        [SerializeField]
        private string itemName;
        [SerializeField]
        [TextArea]        
        private string itemDescription;
        [SerializeField]
        private Sprite itemIcon;
        [SerializeField]
        private GameObject itemPrefab;
    }
}
