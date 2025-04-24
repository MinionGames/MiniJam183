using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Logistics{
    public class Entity : MonoBehaviour
    {
        //// --------DESCRIPTION--------
        /*  This class is a base class for entities:
            they will hold a health and destroy functions.
        */

        //// --------VARIABLES--------
        [Header("Entity Variables")]
        [SerializeField]
        protected float maxHealth;
        [SerializeField]
        protected GameObject deathParticles;

        [SerializeField]
        protected float currentHealth;

        public void DestroySelf() {
            Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        public void ChangeHealth(float changeAmount) {
            currentHealth += changeAmount;
        }

    }
}

