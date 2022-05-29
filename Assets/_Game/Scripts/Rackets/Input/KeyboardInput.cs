using UnityEngine;

namespace Core
{
    public class KeyboardInput : IPlayerInput
    {
        public AxisState GetAxisState()
        {
            var leftPressed = Input.GetKey(KeyCode.A); 
            var rightPressed = Input.GetKey(KeyCode.D);
            
            if (leftPressed && !rightPressed)
                return AxisState.Negative;
            else if (rightPressed && !leftPressed)
                return AxisState.Positive;
            else
                return AxisState.Neutral;
        }
    }
}