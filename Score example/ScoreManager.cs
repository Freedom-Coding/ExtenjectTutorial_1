using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TestExtenject
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score;

        public void IncreaseScore()
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}