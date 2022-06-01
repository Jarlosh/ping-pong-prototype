using UnityEngine;

namespace Core.Rackets.Input
{
    public class KeyboardInput : IPlayerInput
    {
        public AxisState GetAxisState()
        {
            var leftPressed = UnityEngine.Input.GetKey(KeyCode.A); 
            var rightPressed = UnityEngine.Input.GetKey(KeyCode.D);
            
            if (leftPressed && !rightPressed)
                return AxisState.Negative;
            else if (rightPressed && !leftPressed)
                return AxisState.Positive;
            else
                return AxisState.Neutral;
        }
    }
}