using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logistics;

namespace Game.Player{
    public class PlayerControls : MonoBehaviour
    {
        
        // --------DESCRIPTION--------
        /* 
            This script is responsible for
            player controls and movement. 
        */
        // Behavior
        [Header("Behavior")]
        public float moveSpeed;
        public Transform shootFrom;

        // Private Variables
        private Vector2 input;
        private Vector2 movement;
        private Vector2 mouseInput;

        // References
        [Header("References")]
        [SerializeField]
        private Camera cam;
        //private TimeManager timeManager;

        // Calculation Variables
        private float moveSmoothness;

        private Rigidbody2D rb;

        //// --------METHODS--------
        // Awake (Unity)
        void Awake()
        {
            //timeManager = GameObject.Find("Time Manager").GetComponent<TimeManager>();
            rb = GetComponent<Rigidbody2D>();
        }

        // Update (Unity)
        void Update()
        {
            // Movement
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            moveSmoothness = Mathf.Max(input.x, input.y);
            movement = input.normalized * moveSpeed * moveSmoothness;
            

            // Player Rotation
            mouseInput = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mouseInput - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);

        }

        void FixedUpdate()
        {
            rb.MovePosition(transform.position + new Vector3(movement.x * moveSpeed * Time.deltaTime, movement.y * moveSpeed * Time.deltaTime, 0f));
        }

    }
}

