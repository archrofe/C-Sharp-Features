using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Tower : MonoBehaviour
    {
        public Cannon cannon;
        public float attackRate = 0.25f;
        public float attackRadius = 5f;

        private float attackTimer = 0f;
        private List<Enemy> enemies = new List<Enemy>();

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // SET attackTimer = attackTimer + deltaTime
            attackTimer = attackTimer + Time.deltaTime;

            // IF attackTimer >= attackRate
            if (attackTimer >= attackRate)
            {
                // CALL Attack()
                Attack();

                // SET attackTimer = 0
                attackTimer = 0;
            }
        }

        void OnTriggerEnter(Collider col)
        {
            // LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();

            // IF e != null
            if (e != null)
            {
                // Add e to enemies list
                enemies.Add(e);
            }
        }

        void OnTriggerExit(Collider col)
        {
            // LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();

            // IF e != null
            if (e != null)
            {
                // Remove e from enemies list
                enemies.Remove(e);
            }
        }

        Enemy GetClosestEnemy()
        {
            // LET closest = null
            Enemy closest = null;

            // LET minDistance = float.MaxValue
            float minDistance = float.MaxValue;

            // FOREACH enemy in enemies list
            foreach (Enemy currentEnemy in enemies)
            {
                // LET distance = the distance between transform's position and enemy's position
                float distance = Vector3.Distance(transform.position, currentEnemy.transform.position);

                // IF distance < minDistance
                if (distance < minDistance)
                {
                    // SET minDistance = distance
                    minDistance = distance;

                    // SET closest = enemy
                    closest = currentEnemy;
                }
            }

            // RETURN closest
            return closest;
        }

        void Attack()
        {
            // LET closest to GetClosestEnemy()
            Enemy closest = GetClosestEnemy();

            // IF closest != null
            if (closest != null)
            {
                // CALL cannon.Fire() and pass closest as argument
                cannon.Fire(closest);
            }
        }
    }
}
