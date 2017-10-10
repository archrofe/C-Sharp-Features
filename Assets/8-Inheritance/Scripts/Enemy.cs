﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy")]
        public Transform target;
        public int health = 100;
        public int damage = 20;
        public float attackRange = 2f;
        public float attackRate = .5f;

        private float attackTimer = 0f;
        private NavMeshAgent nav;
        private Rigidbody rigid;

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        void Update()
        {
            // Increase attack timer
            attackTimer += Time.deltaTime;
            // Get distance from enemy to target
            float distance = Vector3.Distance(transform.position, target.position);
            // IF distance < attack range
            if (distance < attackRange)
            {
                // Call Attack()
                Attack();
                // Reset attack timer
                attackTimer = 0f;
            }
            // IF target != null
            if (target != null)
            {
                // Navigate to target
                nav.SetDestination(target.position);
            }
        }

        public virtual void Attack()
        {

        }
    }
}