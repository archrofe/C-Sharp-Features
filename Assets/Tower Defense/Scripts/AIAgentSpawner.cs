using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class AIAgentSpawner : MonoBehaviour
    {
        public GameObject aiAgentPrefab;
        public Transform target;
        public float spawnRate = 1f;
        public float spawnRadius = 1f;

        // Use this for initialization
        void Start()
        {
            // InvokeRepeating(functionName, time, repeatRate)
            // functionName = name of the function you want to call in class
            // time = delay for when the function gets called the first time
            // repeatRate = how often the function gets called
            InvokeRepeating("Spawn", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Visualization code
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            // Draw a sphere to indicate the spawn radius
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        void Spawn()
        {
            // LET clone = new instance of aiAgentPrefab
            GameObject clone = Instantiate(aiAgentPrefab);

            // LET rand = Random Inside Unit Sphere
            Vector3 rand = Random.insideUnitSphere;

            // SET rand.y = 0
            rand.y = 0;

            // SET clone's position to transform's position + rand x spawnRadius
            clone.transform.position = transform.position + rand * spawnRadius;

            // SET aiAgent = clone's AIAgent component
            TowerDefense aiAgent = clone.GetComponent<TowerDefense>();

            // SET aiAgent.target = target
            aiAgent.target = target;
        }
    }
}
