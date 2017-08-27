using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopArrays
{
    public class Loops : MonoBehaviour
    {
        public GameObject[] spawnPrefabs;
        public float frequency = 3f;
        public float amplitude = 6f;
        public int spawnAmount = 1000;
        public float spawnRadius = 5f;
        public string message = "Print This";
        private float printTime = 2f;

        private float timer = 0;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            /*
            while (condition)
            {
                // Statement
            }
            */
            SpawnObjectsWithSine();
        }

        void SpawnObjectsWithSine()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                int randomIndex = Random.Range(0, spawnPrefabs.Length);
                // Store randomly seleced prefab
                GameObject randomPrefab = spawnPrefabs[randomIndex];
                // Instantiate randomly selected prefab
                GameObject clone = Instantiate(randomPrefab);
                // Grab the MeshRenderer
                Renderer rend = clone.GetComponent<Renderer>();
                // Change the color
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                rend.material.color = new Color(r, g, b);
                // Generated random position within 2D sphere
                float x = Mathf.Sin(i * frequency) * amplitude;
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                Vector3 randomPos = transform.position + new Vector3(x, y, z);
                // Set spawned object's position
                clone.transform.position = randomPos;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //// Loop through until timer gets to printTime
            //while (timer <= printTime)
            //{
            //    // Count up timer in seconds
            //    timer += Time.deltaTime;
            //    print("OH HI MARK!");
            //}
            /*
           for (initialization; condition; iteration)
           {
                // Statement(s)
           }
           */
        }
    }
}
