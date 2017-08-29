using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Blocks : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                Destroy(gameObject);
            }
        }
    }
}