using UnityEngine;

namespace Core
{
    public class AspectBasedScaler : MonoBehaviour
    {
        [SerializeField] private Transform controlledTransform;
        // [SerializeField] private Vector2 localViewportSize;
        
        [SerializeField] private float targetWidth;
        [SerializeField] private float targetHeight;
        
        private void Start()
        {
            var camera = ViewportManager.Camera;
            var vWidth = Screen.width;//camera.pixelWidth;
            var vHeight = Screen.height;//camera.pixelHeight;

            var scale = controlledTransform.lossyScale;
            var width = scale.x * (vWidth / targetWidth);
            var height = scale.y * (vHeight / targetHeight);
            controlledTransform.localScale = new Vector3(width, height, 1);
        }
    }
}