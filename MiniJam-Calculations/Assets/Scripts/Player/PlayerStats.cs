using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logistics;
using TMPro;

namespace Game.Player{
    public class PlayerStats : Entity
    {

        //// --------DESCRIPTION--------
        /*  This class will keep track of all
            the stats for the player, including:
                Health
                Stamina
                etc...
        */

        //// --------VARIABLES--------
        // Singleton
        private static PlayerStats statsInstance;
        public static PlayerStats Instance{
            get{
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

        public void AddPoints(int points){
            this.points += points;
        }

        public float GetHealth(){
            return currentHealth;
        }

    }
}

