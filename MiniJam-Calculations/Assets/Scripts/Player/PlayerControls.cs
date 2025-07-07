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
            // Input
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            sprinting = Input.GetKey(KeyCode.LeftShift);

            // Movement
            moveSmoothness = Mathf.Max(Mathf.Abs(input.x), Mathf.Abs(input.y));
            movement = input.normalized * moveSpeed * moveSmoothness;
            if (sprinting)
            {
                movement *= sprintFactor;
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
        }

    }
}

