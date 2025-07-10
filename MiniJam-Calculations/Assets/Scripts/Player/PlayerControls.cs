using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logistics;

namespace Game.Player{
    /// <summary>
    /// Singleton manager for player controls and movement.
    /// </summary>
    public class PlayerControls : MonoBehaviour
    {

        // --------DESCRIPTION--------
        /* 
            This script is responsible for
            player controls and movement. 
        */

        public static PlayerControls playerInstance;
        public static PlayerControls Instance
        {
            get
            {
                if (playerInstance == null)
                    playerInstance = new PlayerControls();
                return playerInstance;
            }
        }

        // Behavior
        [Header("Behavior")]
        public float moveSpeed;
        public Transform shootFrom;
        public float sprintFactor;
        public bool sprinting;
        public float sneakFactor;
        public bool sneak;
        public bool canDash;
        public float dashAmount;
        public float dashCooldown;

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
        private float timer;

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
            // Input
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            sprinting = Input.GetKey(KeyCode.LeftShift);
            sneak = Input.GetKey(KeyCode.C);

            // Movement
            moveSmoothness = Mathf.Max(Mathf.Abs(input.x), Mathf.Abs(input.y));
            movement = input.normalized * moveSpeed * moveSmoothness;
            if (moveSmoothness < 0.1f || (sprinting && sneak)) // If no input, stop moving
            {
                movement = Vector2.zero;
            }
            else if (sprinting)
            {
                movement *= sprintFactor;
            }
            else if (sneak)
            {
                movement *= sneakFactor;
            }
            // Dash
            if (timer >= dashCooldown)
            {
                canDash = true; // Reset dash ability after cooldown
            }

            if (Input.GetKeyDown(KeyCode.Space) && canDash && input.magnitude > 0.1f)
            {
                // Implement dash logic here
                // For example, you could set a dash speed and direction
                Vector2 dashMovement = input.normalized * dashAmount;
                transform.position = transform.position + new Vector3(input.normalized.x, input.normalized.y) * dashAmount;
                canDash = false; // Disable dashing until cooldown is over
                timer = 0f;
            }

            // Player Rotation
            mouseInput = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mouseInput - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);

        }

        void FixedUpdate()
        {
            rb.MovePosition(transform.position + new Vector3(movement.x, movement.y, 0f) * Time.fixedDeltaTime);

            timer += Time.fixedDeltaTime;
        }

    }
}

