using Crystal;
using UnityEngine;

namespace Tools.Scaling
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
            var viewPort = GetSafeViewport();
            var x = (viewportPoint.x * viewPort.width + viewPort.x) * Screen.width; 
            var y = (viewportPoint.y * viewPort.height + viewPort.y) * Screen.height; 
            return new Vector2(x, y);
        }

        //todo: cache it
        private static Rect GetSafeViewport()
        {
            var safeArea = GetSafeArea();
            var viewPort = new Rect(safeArea);
            viewPort.x /= Screen.width;
            viewPort.y /= Screen.height;
            viewPort.width /= Screen.width;
            viewPort.height /= Screen.height;
            return viewPort;
        }

        private static Rect GetSafeArea()
        {
            return SafeAreaHelper.GetSafeArea();
        }
    }
}