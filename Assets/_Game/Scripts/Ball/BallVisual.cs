using UnityEngine;

namespace Core
{
    public class BallVisual : MonoBehaviour
    {
        [SerializeField] private Transform scaleTransform;
        [SerializeField] private Renderer renderer;
        private BallConfig config;

        public void SetConfig(BallConfig config)
        {
            this.config = config;
            ApplyConfig();
        }

        private void ApplyConfig()
        {
            var moveConfig = config.moveConfig;
            scaleTransform.localScale = Vector3.one * moveConfig.Size;
            renderer.material.color = config.color;
        }
    }
}