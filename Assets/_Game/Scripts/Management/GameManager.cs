using System;
using UnityEngine;

namespace Core.Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BallFacade ball;
        [SerializeField] private ConfigProviderData configProviderData;

        private void Start()
        {
            ball.OnGoalEvent += OnGoal;

            InitGame();
            StartGame();
        }

        private void OnDestroy()
        {
            ball.OnGoalEvent -= OnGoal;
        }

        private void InitGame()
        {
        }

        private void StartGame()
        {
            var config = configProviderData.PickConfig();
            ball.SetConfig(config);
            ball.Reset();
        }

        private void OnGoal()
        {
            StartGame();
        }
    }
}