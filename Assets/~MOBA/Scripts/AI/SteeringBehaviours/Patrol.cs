using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    [RequireComponent(typeof(PathFollowing))]
    public class Patrol : MonoBehaviour
    {
        public AIAgentPatrolSelector patrolSelector;

        private int currentPoint = 0;
        private PathFollowing pathFollowing;
        private List<Transform> patrolPoints;

        // Use this for initialization
        void Start()
        {
            pathFollowing = GetComponent<PathFollowing>();
        }

        // Update is called once per frame
        void Update()
        {
            if(patrolSelector != null)
            {
                patrolPoints = patrolSelector.patrolPoints;
                if (patrolPoints.Count > 0)
                {
                    if (pathFollowing.isAtTarget)
                    {
                        pathFollowing.currentNode = 0;
                        currentPoint++;
                    }

                    int lastIndex = patrolPoints.Count - 1;
                    if (currentPoint >= patrolPoints.Count)
                    {
                        currentPoint = 0;
                    }

                    Transform point = patrolPoints[currentPoint];
                    pathFollowing.target = point;
                }
            }
        }
    }
}