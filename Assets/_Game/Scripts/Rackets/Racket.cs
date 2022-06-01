using UnityEngine;

namespace Core.Rackets
{
    public class Racket : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D visualRb;
        [SerializeField] private Collider2D collider;

        public Vector2 Position => visualRb.position;

        public void SetVelocity(float direction, float moveSpeed)
        {
            visualRb.velocity = Vector3.right * (direction * moveSpeed);
        }
    }
}