using Core.Ball;
using Tools.Scaling;
using Core.Rackets.Input;
using UnityEngine;

namespace Core.Rackets
{
    public class OpponentAI : MonoBehaviour
    {
        [SerializeField] private InputAxis inputAxis;
        [SerializeField] private BallMovement ball;
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