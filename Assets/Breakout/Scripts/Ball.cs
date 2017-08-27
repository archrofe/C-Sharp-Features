using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        public float speed = 20f; // Speed at which the ball travels
        public Text countText;

        private Vector3 velocity; // Direction x Speed
        private int count;

        public void Fire(Vector3 direction)
        {
            velocity = direction * speed;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            // Grab the contact point of collsion
            ContactPoint2D contact = other.contacts[0];
            // Calculate the reflection point of the ball using velocity & contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            // Calculate new velocity from reflection multiply by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
        }

        // Use this for initialization
        void Start()
        {
            count = 0;
            SetCountText();
        }

        // Update is called once per frame
        void Update()
        {
            // Moves ballusing velocity & deltaTime
            transform.position += velocity * Time.deltaTime;
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
        }

        void SetCountText()
        {
            countText.text = "Count: " + count.ToString();
        }
    }
}