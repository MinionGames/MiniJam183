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
        public float dashDistance = 5f;

        // Private Variables
        private Vector2 input;
        private Vector2 movement;
        private Vector2 mouseInput;
        private bool pickedUpWeapon;


        // References
        [Header("References")]
        [SerializeField]
        private Camera cam;
        //private TimeManager timeManager;

        // Temporary Variables
        [Header("TEMP")]
        public GameObject bulletPrefab;

        // Ability Properties
        private bool hasDash {get; set;}
        private bool hasSlow {get; set;}
        private bool hasJumper {get; set;}

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

            // Shoot
            if (Input.GetMouseButtonDown(0) /*&& pickedUpWeapon*/){
                GameObject projectile = Instantiate(bulletPrefab, shootFrom.position, shootFrom.rotation);
                //projectile.GetComponent<Projectile>().Settings(this.gameObject);
                // TEMP
                transform.GetChild(1).GetComponent<Animator>().SetTrigger("Shoot");
            }

            // Special Abilities
            if (Input.GetKeyDown(KeyCode.Space)){ // Dash
                transform.position += transform.up * dashDistance;
            }
            else if(Input.GetKeyDown(KeyCode.E)){ // Slow Down Time
                //timeManager.SlowTimeScale(0.5f);
            }

        }

        void OnCollisionStay2D(Collision2D col)
        {
            if(col.gameObject.name.Equals("Weapon Pickup"))
            {
                if (Input.GetKeyDown(KeyCode.F)){
                    transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                    pickedUpWeapon = true;
                }
                
            }
        }

    }
}

