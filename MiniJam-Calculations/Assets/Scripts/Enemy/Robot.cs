using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Logistics;
using UnityEngine.UIElements;

namespace Game.Enemy
{
    public class Robot : Entity
    {
        //// --------DESCRIPTION--------
        /*
            This is the script for the generic robot.
        */

        [Header("Generic Robot Settings")]
        [SerializeField]
        private float moveSpeed = 10;

        [SerializeField]
        private float FOV = 20;

        [SerializeField]
        private int damage = 5;

        [SerializeField]
        private bool melee = true;

        [Header("Dev Settings")]
        //The 'followPlayer' variable was not showing and the '[SerializeField]' was invalid, so i removed the '{ get; set; }' after the 'followPlayer'.
        //This worked, however I do not know what this changed, so... yeah... we'll see...
        [SerializeField]
        private bool followPlayer;

        [SerializeField]
        private int stunnedTime;

        [SerializeField]
        private GameObject nextPatrolLocation;

        [SerializeField]
        private bool panic;
        //This occurs during the escpae coundown and causes random motion from robots instead of patrolling. Robots will still chase player.

        private Rigidbody2D rb;

        [SerializeField]
        private GameObject playerObject;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector2 playerPosition = new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
            if (followPlayer)
            {
                //Only look at player if it is following the player, but I don't know what I'm doing...
                Vector2 lookDir = playerPosition - new Vector2(transform.position.x, transform.position.y);
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);
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

