using System;
using System.Linq;
using Scoring;
using Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class BallFacade : MonoBehaviour
    {
        [SerializeField] private BallVisual visual;
        [SerializeField] private BallMovement movement;
        [SerializeField] private BallCollider collider;
        
        public event Action<GoalGate> OnGoalEvent;

        private void Start()
        {
            collider.OnGoalCollisionEvent += OnGoal;
        }

        private void OnDestroy()
        {
            collider.OnGoalCollisionEvent -= OnGoal;
        }

        public void SetConfig(BallConfig config)
        {
            visual.SetConfig(config);
            movement.SetConfig(config.moveConfig);
        }

        private void OnGoal(GoalGate goalGate)
        {
            OnGoalEvent?.Invoke(goalGate);
        }

        public void Reset()
        {
            movement.Reset();
            CoroutineHelpers.DoAfter(this, 1f, () 
                => movement.SetMoveDirection(PickStartDirection()));
        }

        private Vector2 PickStartDirection()
        {
            // var x = JRandom.CoinFlip() ? 1 : -1;
            var x = 0;
            var y = JRandom.CoinFlip() ? 1 : -1;
            return new Vector2(x, y);
        }
    }
}