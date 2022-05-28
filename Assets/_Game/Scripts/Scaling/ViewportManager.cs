using UnityEngine;

namespace Core
{
    public class ViewportManager
    {
        private static Camera _camera;
        
        public static float WorldWidth { get; private set; }
        public static float WorldHeight { get; private set; }

        public static Camera Camera => _camera ?? (_camera = Camera.main);

        static ViewportManager()
        {
            WorldWidth = DistBetween(Vector2.zero, Vector2.right);
            WorldHeight = DistBetween(Vector2.zero, Vector2.up);
        }

        private static float DistBetween(Vector2 viewportPoint1, Vector2 viewportPoint2)
        {
            var start = ViewportToWorld(viewportPoint1);
            var end = ViewportToWorld(viewportPoint2);
            return (end - start).magnitude;
        }
        
        public static Vector2 ViewportToWorld(Vector2 viewportPoint)
            => Camera.ScreenToWorldPoint(ViewportToScreen(viewportPoint));
        
        public static Vector2 ViewportToScreen(Vector2 viewportPoint)
        {
            return new Vector2(viewportPoint.x * Screen.width, viewportPoint.y * Screen.height);
        }
    }
}