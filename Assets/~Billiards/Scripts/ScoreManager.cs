using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Billiards
{
    public class ScoreManager : MonoBehaviour
    {
        public Text scoreText;

        private int score = 0;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            UpdateScore();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pocket"))
            {
                Destroy(other.gameObject);
                score = score + 1;
                UpdateScore();
            }
        }

        void UpdateScore()
        {
            scoreText.text = "Score: " + score;
        }
    }
}