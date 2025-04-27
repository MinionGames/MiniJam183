using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logistics;

namespace Game.Player{
    public class PlayerControls : MonoBehaviour
    {
        
        // --------DESCRIPTION--------
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

        //// --------METHODS--------
        // Awake (Unity)
        void Awake()
        {
            //timeManager = GameObject.Find("Time Manager").GetComponent<TimeManager>();
        }

        // Update (Unity)
        void Update()
        {
            // Movement
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            float moveSmoothness = Mathf.Max(input.x, input.y);

            movement = input.normalized * moveSpeed * moveSmoothness;
            transform.position = transform.position + new Vector3(input.x * moveSpeed * Time.deltaTime, input.y * moveSpeed * Time.deltaTime, 0f);

            // Player Rotation
            mouseInput = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mouseInput - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);

        }

    }
}

