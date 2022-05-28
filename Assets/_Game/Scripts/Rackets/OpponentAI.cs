using System;
using UnityEngine;

namespace Core
{
    public class OpponentAI : MonoBehaviour
    {
        [SerializeField] private InputAxis inputAxis;
        [SerializeField] private BallController ball;
        [SerializeField] private Racket racket;
        [SerializeField] private float viewPortAccuracy;
        [SerializeField] private float moveSpeed = 1;

        private void FixedUpdate()
        {
            UpdateInput();
            racket.SetVelocity(inputAxis.Value, ViewportManager.WorldWidth * moveSpeed);
        }

        private void UpdateInput()
        {
            var dx = ball.Position.x - racket.Position.x;
            var accuracy = viewPortAccuracy * ViewportManager.WorldWidth;

            if (Mathf.Abs(dx) < accuracy)
                inputAxis.State = AxisState.Neutral;
            else if (dx < 0)
                inputAxis.State = AxisState.Negative;
            else
                inputAxis.State = AxisState.Positive;
        }
    }
}