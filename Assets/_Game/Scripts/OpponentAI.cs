using System;
using UnityEngine;

namespace Core
{
    public class OpponentAI : MonoBehaviour
    {
        [SerializeField] private Racket racket;
        [SerializeField] private BallController ball;
        [SerializeField] private float moveSpeed;
        
        private const float Accuracy = 0.025f;

        private void Update()
        {
            var dx = ball.Position.x - racket.Position.x;
            if(Math.Abs(dx) > Accuracy)
                Move(dx);
        }
        
        private void Move(float dx)
        {
            var sign = Mathf.Sign(dx);
            var value = Mathf.Min(Mathf.Abs(dx), 1f);
            var speed = sign * value * moveSpeed * Time.deltaTime;
            racket.Velocity = Vector2.right * speed;
        }
    }
}