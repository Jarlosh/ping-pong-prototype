using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ballRb;
        [SerializeField] private float moveSpeed;

        public Vector2 Position => ballRb.position;
        
        private void Start()
        {
            SetMoveDirection(PickStartDirection());
        }

        private Vector2 PickStartDirection()
        {
            var x = Random.value > 0.5f ? 1 : -1;
            var y = Random.value > 0.5f ? 1 : -1;
            return new Vector2(x, y);
        }

        private void SetMoveDirection(Vector2 direction)
        {
            ballRb.velocity = direction.normalized * moveSpeed;
        }

        private void FixedUpdate()
        {
            ballRb.velocity = ballRb.velocity.normalized * moveSpeed;
        }
    }
}