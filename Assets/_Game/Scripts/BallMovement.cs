using System;
using UnityEngine;

namespace Core
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ballRb;
        [SerializeField] private BallCollider collider;
        [SerializeField] private float moveSpeed;
        
        public Vector2 Position => ballRb.position;
        public Vector3 Velocity => ballRb.velocity;

        private void Start()
        {
            collider.OnRacketCollisionEvent += RacketBounce;
        }

        private void OnDestroy()
        {
            collider.OnRacketCollisionEvent -= RacketBounce;
        }

        public void Reset()
        {
            ballRb.position = Vector2.zero;
        }
        
        public void SetMoveDirection(Vector2 direction)
        {
            ballRb.velocity = direction.normalized * moveSpeed;
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