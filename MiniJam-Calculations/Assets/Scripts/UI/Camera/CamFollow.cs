using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Visuals.Camera{
    public class CamFollow : MonoBehaviour
    {
        
        //// --------DESCRIPTION--------
        /*  This script enables the camera to smoothly
            follow a target.
        */

        //// --------VARIABLES--------
        // Input Variables (User-Defined)
        [SerializeField]
        private GameObject player;
        [SerializeField]
        private float followSmoothness = 10f;
        public bool followPlayer;

        // Input Variables (Non-User-Defined)
        private float followCutOffMin = 0.1f;

        // Components
        private Rigidbody2D rb;

        // Calculation Variables
        [HideInInspector]
        public Vector3 target;


        //// --------METHODS--------
        // Start Method (Unity)
        void Start(){
            // --Initialize--
            followPlayer = true;
            rb = GetComponent<Rigidbody2D>();
        }

        // Update Method (Unity)
        void Update(){
            if(followPlayer){ // Check whether to follow player or not
                target = player.transform.position; // If yes, set target to player pos
            }

            // --Move Camera--
            Vector3 movePos = (target - transform.position); // Get difference vector
            
            // Determine whether to move
            Vector2 distance2D = new Vector2(movePos.x, movePos.y);
            if (distance2D.magnitude >= followCutOffMin){
                movePos /= followSmoothness;
                movePos.z = 0; // Make sure z doesn't move
                transform.position = transform.position + movePos * Time.deltaTime; // Apply follow vector
            }
                
        }

        // Fixed Update Method (Unity)
        void FixedUpdate(){
            // Smoothly move camera to player pos
            // Vector2 camPos2D = new Vector2(rb.position.x, rb.position.y);
            // rb.MovePosition(Vector2.Lerp(camPos2D, target, followSmoothness));
        }

    }
}

