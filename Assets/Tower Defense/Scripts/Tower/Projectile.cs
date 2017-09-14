using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Projectile : MonoBehaviour
    {
        public float damage = 50f;
        public float speed = 50f;
        public Vector3 direction;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Projectile to travel at our calculated velocity

            // LET velocity = direction.normalized x speed
            Vector3 velocity = direction.normalized * speed;

            // SET projectile's position += velocity x deltaTime
            transform.position += velocity * Time.deltaTime;
        }

        void OnTriggerEnter(Collider col)
        {
            // LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();

            // IF e != null
            if (e != null)
            {
                // CALL e.DealDamage(damage)
                e.DealDamage(damage);

                // Destroy gameObject
                Destroy(gameObject);
            }

            // IF col's name == "Ground"
            if (col.name == "Ground")
            {
                // Destroy the projectile
                Destroy(gameObject);
            }
        }
    }
}
