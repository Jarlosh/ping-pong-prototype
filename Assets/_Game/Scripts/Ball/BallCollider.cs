using System;
using Scoring;
using Tools;
using UnityEngine;

namespace Core
{
    public class BallCollider : MonoBehaviour
    {
        [SerializeField] private LayerMask racketLayer;

        public event Action<GoalGate> OnGoalCollisionEvent;
        public event Action<Collision2D> OnRacketCollisionEvent;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var go = other.gameObject;
            if(racketLayer.Contains(go.layer))
                OnRacketCollisionEvent?.Invoke(other);
            else if (go.TryGetComponent<GoalGate>(out var gate))
                OnGoalCollisionEvent?.Invoke(gate);
        }
    }
}