using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Cannon : MonoBehaviour
    {
        public Transform barrel;
        public GameObject projectilePrefab;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Fire(Enemy targetEnemy)
        {
            // LET targetPos = targetEnemy's position
            Vector3 targetPos = targetEnemy.transform.position;

            // LET barrelPos = barrel's position
            Vector3 barrelPos = barrel.transform.position;

            // LET barrelRot = barrel's rotation
            Quaternion barrelRot = barrel.transform.rotation;

            // LET fireDirection = targetPos - barrelPos
            Vector3 fireDirection = targetPos - barrelPos;

            // SET cannon's rotation = Quaternion.LookRotation(fireDirection, Vector3.up)
            transform.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);

            // LET clone = instantiate(projectilePrefab, barrelPos, barrelRot)
            GameObject clone = Instantiate(projectilePrefab, barrelPos, barrelRot);

            // LET p = clone's Projectile component
            Projectile p = clone.GetComponent<Projectile>();

            // SET p.direction = fireDirection
            p.direction = fireDirection;
        }
    }
}
