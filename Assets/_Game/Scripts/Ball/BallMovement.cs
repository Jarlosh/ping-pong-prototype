using UnityEngine;

namespace Core.Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ballRb;
        [SerializeField] private BallCollider collider;
        [SerializeField, Range(0, 5)] private float speedIncreasePerBounce;
        private BallMoveConfig config;
        private int bounces;

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

        public void SetConfig(BallMoveConfig config)
        {
            this.config = config;
        }
        
        public void Reset()
        {
            ballRb.position = Vector2.zero;
            ballRb.velocity = Vector2.zero;
            bounces = 0;
        }
        
        public void SetMoveDirection(Vector2 direction)
        {
            ballRb.velocity = direction.normalized * (config.MoveSpeed + bounces * speedIncreasePerBounce);
        }
        
        private void RacketBounce(Collision2D collision)
        {
            bounces++;
            var dx = collision.contacts[0].point.x - collision.gameObject.transform.position.x;
            var width = collision.collider.bounds.size.x;

            var x = dx / width;
            var y = Mathf.Sign(-ballRb.position.y);
            
            SetMoveDirection(new Vector2(x, y));
        }
    }
}