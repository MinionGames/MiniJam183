using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Logistics;
using Unity.VisualScripting;
using static UnityEngine.RuleTile.TilingRuleOutput;
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
        private float moveSpeed;

        [Header("Dev Settings")]
        [SerializeField]
        private bool followPlayer { get; set; }

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
            Vector2 lookDir = playerPosition - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);
        }
    }
}

