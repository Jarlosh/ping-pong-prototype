using Core.Ball;
using Meta.Scoring;
using UnityEngine;

namespace Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BallFacade ball;
        [SerializeField] private ScoreManager score;
        [SerializeField] private ConfigProviderData configProviderData;

        private void Awake()
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }

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

        private void OnGoal(GoalGate goalGate)
        {
            score.AddScore(goalGate.IsPlayerSide);
            StartGame();
        }
    }
}