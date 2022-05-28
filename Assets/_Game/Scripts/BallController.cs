using System;
using System.Linq;
using Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private BallMovement movement;
        [SerializeField] private BallCollider collider;
        
        public event Action OnGoalEvent;

        private void Start()
        {
            collider.OnGoalCollisionEvent += OnGoal;
        }

        private void OnDestroy()
        {
            collider.OnGoalCollisionEvent -= OnGoal;
        }

        private void OnGoal()
        {
            OnGoalEvent?.Invoke();
        }

        public void Reset()
        {
            movement.Reset();
            movement.SetMoveDirection(PickStartDirection());
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