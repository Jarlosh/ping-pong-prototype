using System;
using Scoring;
using UnityEngine;

namespace _Game.Scripts.UI.HUD
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private ScoreView currentScoreView;
        [SerializeField] private ScoreView bestScoreView;

        private void Start()
        {
            scoreManager.OnBestScoreChanged += OnBestChanged;
            scoreManager.OnScoreChanged += OnScoreChanged;
            OnScoreChanged(scoreManager.Score);
            OnBestChanged(scoreManager.BestScore);
        }

        private void OnDestroy()
        {
            scoreManager.OnBestScoreChanged += OnBestChanged;
            scoreManager.OnScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(Score score)
        {
            currentScoreView.SetScore(score);
        }

        private void OnBestChanged(Score score)
        {
            bestScoreView.SetScore(score);
        }
    }
}