using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Logistics;

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
        private bool followPlayer{get; set;}


    }
}

