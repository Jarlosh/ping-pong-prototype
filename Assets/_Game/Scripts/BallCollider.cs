using System;
using Tools;
using UnityEngine;

namespace Core
{
    public class BallCollider : MonoBehaviour
    {
        [SerializeField] private LayerMask racketLayer;
        [SerializeField] private LayerMask goalLayer;

        public event Action OnGoalCollisionEvent;
        public event Action<Collision2D> OnRacketCollisionEvent;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var go = other.gameObject;
            if(racketLayer.Contains(go.layer))
                OnRacketCollisionEvent?.Invoke(other);
            else if (goalLayer.Contains(go.layer))
                OnGoalCollisionEvent?.Invoke();
        }
    }
}