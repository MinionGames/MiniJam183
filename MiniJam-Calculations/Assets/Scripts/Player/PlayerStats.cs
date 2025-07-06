using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logistics;
using TMPro;

namespace Game.Player{
    /// <summary>
    /// Singleton responsible for keeping track of the player's stats, such as health, stamina, and points.
    /// <para>
    /// This class is a singleton, there is only one instance of it in the game. 
    /// To access: PlayerStats.Instance
    /// </para>
    /// </summary>
    public class PlayerStats : Entity
    {
        /// --------VARIABLES--------
        // Singleton
        private static PlayerStats statsInstance;
        public static PlayerStats Instance
        {
            get
            {
                if (statsInstance == null)
                    statsInstance = new PlayerStats();
                return statsInstance;
            }
        }

        // Input
        [Header("Player Restrictions")]
        public float maxStamina;
        //public HealthBar healthBar;
        public TMP_Text text;

        [HideInInspector]
        public float currentStamina;
        [HideInInspector]
        public int points;

        //// --------METHODS--------
        // Start (Unity)
        void Start()
        {
            currentHealth = maxHealth;
        }

        // Update (Unity)
        void Update()
        {
            //ealthBar.SetHealth(currentHealth);
            text.text = "Points: " + points;
        }

        /// <summary>
        /// Adds points to the player's score.
        /// </summary>
        /// <param name="points"></param>
        /// <returns>None</returns>
        public void AddPoints(int points)
        {
            this.points += points;
        }

        /// <summary>
        /// Gets the current health of the player.
        /// </summary>
        /// <returns>float currentHealth</returns>
        public float GetHealth()
        {
            return currentHealth;
        }

    }
}

