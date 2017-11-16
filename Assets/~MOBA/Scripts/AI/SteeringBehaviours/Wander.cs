﻿using UnityEngine;
using System.Collections;

using GGL;

namespace MOBA
{
    public class Wander : SteeringBehaviour
    {
        public float offset = 1f;
        public float radius = 1f;
        public float jitter = .2f;

        private Vector3 targetDir;
        private Vector3 randomDir;

        public override Vector3 GetForce()
        {
            // Force starts at zero (no velocity)
            Vector3 force = Vector3.zero;

            // Randomise range between values
            float randX = Random.Range(0, 0x7fff) - (0x7fff * .5f);
            float randZ = Random.Range(0, 0x7fff) - (0x7fff * .5f);

            #region Calculate Random Direction
            // Create the random direction vector
            randomDir = new Vector3(randX, 0, randZ);
            // Normalise the random direction
            randomDir = randomDir.normalized;
            //randomDir.Normalize();
            // Multiply jitter to randomDir
            randomDir *= jitter;
            #endregion

            #region Calculate Target Direction
            // Append target dir with randomDir
            targetDir += randomDir;
            // Normalise the target dir
            targetDir = targetDir.normalized;
            //targetDir.Normalize();
            // Amplify it by the radius
            targetDir *= radius;
            #endregion

            // Calculate seek position using targetDir
            Vector3 seekPos = transform.position + targetDir;
            seekPos += transform.forward.normalized * offset;

            #region GizmosGl
            Vector3 forwardPos = transform.position + transform.forward.normalized * offset;
            Circle c = GizmosGL.AddCircle(forwardPos + Vector3.up * .1f, radius, Quaternion.LookRotation(Vector3.down));
            c.color = new Color(1, 0, 0, .5f);
            GizmosGL.AddCircle(seekPos + Vector3.up * .15f, radius * .6f, Quaternion.LookRotation(Vector3.down));
            c.color = new Color(0, 0, 1, .5f);

            #endregion

            #region Wander
            // Calculate direction
            Vector3 direction = seekPos - transform.position;
            // Is direction valid? (not zero)
            if (direction.magnitude > 0)
            {
                // Calculate force
                Vector3 desiredForce = direction.normalized * weighting;
                force = desiredForce - owner.velocity;
            }
            #endregion

            return force;
        }
    }
}

// Folds Code       = CTRL + M + O
// Unfolds Code     = CTRL + M + P
// Comment Line     = CTRL + K + C
// Uncomment Line   = CTRL + K + U