using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{

    public class Weapon : MonoBehaviour
    {
        public int damage = 10;
        public int maxBullets = 30;
        public float bulletSpeed = 20f;
        public float fireInterval = .2f;
        public GameObject bulletPrefab;
        public Transform spawnPoint;

        private Bullet[] spawnedBullets;
        private int currentBullets = 0;
        private bool isFired = false;
        private Transform target;

        // Use this for initialization
        void Start()
        {
            spawnedBullets = new Bullet[maxBullets];
        }

        // Update is called once per frame
        void Update()
        {
            // IF !isFired AND currentBullets < maxBullets
            if (!isFired && currentBullets < maxBullets)
            {
                // StartCoroutine Fire()
                StartCoroutine(Fire());
            }
                // StartCoroutine Fire()
        }

        IEnumerator Fire()
        {
            // Run whatever is here first
            isFired = true;

            // Spawn the bullet
            SpawnBullet();

            yield return new WaitForSeconds(fireInterval); // wait a few seconds

            // Run whatever is here last
            isFired = false;
        }

        //Fire a Bullet
        void SpawnBullet()
        {
            // 1. Instantiate a bullet clone
            GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            // 2. Make a direction that goes to target
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            // 3. Rotate the barrel
            Vector3 eulerAngles = transform.eulerAngles;
            float angle = Vector3.Angle(Vector3.right, direction);
            eulerAngles.z = angle;
            transform.eulerAngles = eulerAngles;

            // 4. Grab bullet scipt from clone
            Bullet bullet = clone.GetComponent<Bullet>();

            // 5. Send bullet to target
            bullet.direction = direction;

            // 6. Store bullet in Array
            spawnedBullets[currentBullets] = bullet;

            // 7. Increment currentBullets
            currentBullets++;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}