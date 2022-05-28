using System;
using UnityEngine;

namespace Core.Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BallController ball;

        private void Start()
        {
            ball.OnGoalEvent += OnGoal;

            InitGame();
        }

        private void OnDestroy()
        {
            ball.OnGoalEvent -= OnGoal;
        }

        private void InitGame()
        {
            ball.Reset();
        }

        private void OnGoal()
        {
            ball.Reset();
        }
    }
}