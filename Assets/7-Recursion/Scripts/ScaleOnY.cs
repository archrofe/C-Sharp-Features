using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recursion
{
    public class ScaleOnY : MonoBehaviour
    {
        public float maxScale = 10f;

        private float originalY = 0;
        private float percentY = 0;

        // Use this for initialization
        void Start()
        {
            originalY = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 scale = transform.localScale;
            Vector3 position = transform.position;
            // 0.8 = 80 / 100
            percentY = position.y / originalY;
            // 0.2 = 1 - 0.8
            float inversePercentY = 1 - percentY;
            // 20 = 100 x 0.2
            float scaleFactor = maxScale * inversePercentY;
            // (20, 20, 20) = (1, 1, 1) x 20
            scale = Vector3.one * scaleFactor;

            transform.localScale = scale;
        }
    }
}