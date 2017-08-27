using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Billiards
{
    public class ScoreManager : MonoBehaviour
    {
        public Text scoreText;
        public int scoreValue;

        private int score;

        // Use this for initialization
        void Start()
        {
            score = 0;
            UpdateScore();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pocket"))
            {
                Destroy(gameObject);
                score = score + 1;
                UpdateScore();
            }
        }

        public void AddScore(int newScoreValue)
        {
            score += newScoreValue;
            UpdateScore();
        }

        void UpdateScore()
        {
            scoreText.text = "Score: " + score;
        }
    }
}