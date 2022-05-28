using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputAxis axis;
        [SerializeField] private Racket racket;
        [SerializeField] private float moveSpeed = 1;
        
        private void Update()
        {
            UpdateInput();
            racket.SetVelocity(axis.Value, moveSpeed * ViewportManager.WorldWidth);
        }

        private void UpdateInput()
        {
            var leftPressed = Input.GetKey(KeyCode.A); 
            var rightPressed = Input.GetKey(KeyCode.D);
            
            if (leftPressed && !rightPressed)
                axis.State = AxisState.Negative;
            else if (rightPressed && !leftPressed)
                axis.State = AxisState.Positive;
            else
                axis.State = AxisState.Neutral;
        }
    }
}