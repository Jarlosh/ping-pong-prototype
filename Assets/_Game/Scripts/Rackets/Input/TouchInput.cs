using System.Linq;
using UnityEngine;

namespace Core.Rackets.Input
{
    public class TouchInput : IPlayerInput
    {
        public AxisState GetAxisState()
        {
            if (UnityEngine.Input.touchCount == 0)
                return AxisState.Neutral;

            var touch = UnityEngine.Input.touches.First();
            var viewportX = touch.position.x / Screen.width;
            return viewportX < 0.5 ? AxisState.Negative : AxisState.Positive;
        }
    }
}