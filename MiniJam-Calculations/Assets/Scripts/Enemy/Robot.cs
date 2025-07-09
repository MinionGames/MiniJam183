using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.AI;
using Game.Logistics;
using Game.Player;

namespace Game.Enemy
{
    /// <summary>
    /// Generic Robot Entity
    /// </summary>
    public class Robot : Entity
    {

        [Header("Generic Robot Settings")]
        [SerializeField]
        private bool canMove;
        [SerializeField]
        private float moveSpeed = 10;
        [SerializeField]
        private float FOV = 20;
        [SerializeField]
        private int damage = 5;
        [SerializeField]
        private bool melee = true;

        [Header("Dev Settings")]
        [SerializeField]
        private int stunnedTime;
        public bool panic;
        //This occurs during the escpae coundown and causes random motion from robots instead of patrolling. 
        // Robots will still chase player.

        [Header("Dev Settings")]
        [SerializeField]
        private Vector3 target;

        [SerializeField]
        public bool followPlayer { get; set; }

        private Rigidbody2D rb;
        private NavMeshAgent agent;
        [SerializeField]
        private Transform playerTransform;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            agent.SetDestination(playerTransform.position);
            rb.velocity = Vector2.zero; // Reset velocity to prevent unwanted movement

            // Robot Rotation
            Vector2 playerPosition = new Vector2(playerTransform.position.x, playerTransform.position.y);
            Vector2 lookDir = playerPosition - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);
        }

        private void FixedUpdate()
        {
            Vector2 playerPosition = new Vector2(target.x, target.y);
            if (followPlayer)
            {
                //Only look at player if it is following the player, but I don't know what I'm doing...
                Vector2 lookDir = playerPosition - new Vector2(transform.position.x, transform.position.y);
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);

                // Move Player
                rb.MovePosition(transform.position + transform.up * moveSpeed * Time.fixedDeltaTime);
            }
            Vector2 rayLeft = new Vector2(Mathf.Sin(FOV / 2), Mathf.Cos(FOV / 2));
            Vector2 rayRight = new Vector2(Mathf.Sin(-FOV / 2), Mathf.Cos(FOV / 2));

            RaycastHit2D hit = new RaycastHit2D();


            // If it hits something...
            if (hit)
            {
                // Calculate the distance from the surface and the "error" relative
                // to the floating height.
                float distance = Mathf.Abs(hit.point.y - transform.position.y);

                //I don't know what this above stuff means, so I will just do some things...
                //This doesn't change 'followPlayer'.
                //Uhhhhh
                followPlayer = true;
            }
        }
    }
}

