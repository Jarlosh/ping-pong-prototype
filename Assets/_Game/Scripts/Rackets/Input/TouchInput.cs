using System;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class TouchInput : IPlayerInput
    {
        public AxisState GetAxisState()
        {
            if (Input.touchCount == 0)
                return AxisState.Neutral;

            var touch = Input.touches.First();
            var viewportX = touch.position.x / Screen.width;
            return viewportX < 0.5 ? AxisState.Negative : AxisState.Positive;
        }
    }
}