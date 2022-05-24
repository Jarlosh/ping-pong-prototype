using System;
using System.Linq;
using Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ballRb;
        [SerializeField] private float moveSpeed;
        [SerializeField] private LayerMask racketLayer;
        [SerializeField] private LayerMask goalLayer;

        public Vector2 Position => ballRb.position;
        
        private void Start()
        {
            SetMoveDirection(PickStartDirection());
        }

        private Vector2 PickStartDirection()
        {
            var x = JRandom.CoinFlip() ? 1 : -1;
            var y = JRandom.CoinFlip() ? 1 : -1;
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

        
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var go = other.gameObject;
            if(racketLayer.Contains(go.layer))
                RacketBounce(other);
            else if (goalLayer.Contains(go.layer))
                OnGoal();
        }

        private void OnGoal()
        {
            ballRb.position = Vector2.zero;
            Start();
        }

        private void RacketBounce(Collision2D collision)
        {
            var dx = collision.contacts[0].point.x - collision.gameObject.transform.position.x;
            var width = collision.collider.bounds.size.x;

            var x = dx / width;
            var y = Mathf.Sign(-ballRb.position.y);
            
            SetMoveDirection(new Vector2(x, y));
        }
    }
}