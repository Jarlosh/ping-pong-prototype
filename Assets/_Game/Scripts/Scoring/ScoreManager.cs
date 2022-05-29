using System;
using _Game.Scripts.UI;
using UnityEngine;

namespace Scoring
{
    public struct Score
    {
        public int PlayerScore { get; set; }
        public int OpponentScore { get; set; }

        public int Difference => PlayerScore - OpponentScore;
    }

    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private JsonPrefItem<Score> bestScoreSave;
        
        private Score _score;
        private Score _bestScore;

        public Score BestScore
        {
            get => _bestScore;
            private set
            {
                if (_bestScore.Equals(value))
                    return;
                _bestScore = value;
                bestScoreSave.TrySetValue(value);
                OnBestScoreChanged?.Invoke(value);
            }
        }
        
        public Score Score
        {
            get => _score;
            private set
            {
                if(_score.Equals(value))
                    return;

                _score = value;
                OnScoreChanged?.Invoke(value);   
            }
        }

        public event Action<Score> OnBestScoreChanged;
        public event Action<Score> OnScoreChanged;

        private void Awake()
        {
            _bestScore = new Score();
            if(bestScoreSave.HasKey() && bestScoreSave.TryGetValue(out var score)) 
                BestScore = score;
        }
        
        public void AddScore(bool isPlayerGate)
        {
            var score = Score;
            if (isPlayerGate)
                score.OpponentScore++;
            else 
                score.PlayerScore++;
            Score = score;
            if (IsNewRecord()) 
                BestScore = Score;
        }

        private bool IsNewRecord()
        {
            return Score.Difference > BestScore.Difference;
        }
    }
}