using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float splosionRadius = 5f;
        public float splosionRate = 3f;
        public float impactForce = 10f;
        public GameObject splosionParticles;

        private float splosionTimer = 0f;

        protected override void Update()
        {
            base.Update();

            splosionTimer += Time.deltaTime;
        }

        protected override void OnAttackEnd()
        {
            // If splosionTimer > splosionRate
            if (splosionTimer > splosionRate)
            {
                // Call Explode()
                Splode();
            }
        }

        void Splode()
        {
            // Perform Physics OverlapSphere with splosionRadius
            Collider[] hits = Physics.OverlapSphere(transform.position, splosionRadius);
            // Loop through all hits
            foreach (var hit in hits)
            {
                Health h = hit.GetComponent<Health>();
                // If player
                if (h != null)
                {
                    h.TakeDamage(damage);
                    // Add impact force to rigidbody
                    rigid.AddExplosionForce(impactForce, transform.position, splosionRadius);
                }
                Rigidbody r = hit.GetComponent<Rigidbody>();
                if (r != null)
                {
                    Vector3 dir = hit.transform.position - transform.position;
                    r.AddExplosionForce(impactForce, transform.position, splosionRadius);
                }
            }
            // Destroy self
            Destroy(gameObject);
        }
    }
}