using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float impactForce = 10f;
        public float knockback = 5f;

        private Rigidbody rigidCharger;

        public override void Attack()
        {
            // Add force to self
            Enemy.rigid.AddForce(-transform.forward * knockback);
        }

        void OnCollisionEnter(Collision col)
        {
            // If collision hits player
            if (col.gameObject.name == "Player")
            {
                // Add impactForce to player
                col.rigidbody.AddForce(transform.forward * impactForce);
                Debug.Log("Added impactForce to Player");
            }
        }
    }
}