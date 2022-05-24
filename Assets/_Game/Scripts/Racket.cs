using UnityEngine;

namespace Core
{
    public class Racket : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D visualRb;
        
        public Vector2 Velocity
        {
            get => visualRb.velocity;
            set => visualRb.velocity = value;
        }

        public Vector2 Position => visualRb.position;
    }
}