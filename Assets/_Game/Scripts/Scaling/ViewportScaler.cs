using UnityEngine;

namespace Tools.Scaling
{
    public class ViewportScaler : MonoBehaviour
    {
        [SerializeField] private Vector2 localViewportSize;

        private void Start()
        {
            var width = ViewportManager.WorldWidth * localViewportSize.x;            
            var height = ViewportManager.WorldHeight * localViewportSize.y;
            transform.localScale = new Vector3(width, height, 1);
        }
    }
}