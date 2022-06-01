using UnityEngine;

namespace Tools.Scaling
{
    public class ViewportPosition : MonoBehaviour
    {
        [SerializeField] private Vector2 viewportPoint;
        
        private void Start()
        {
            transform.position = ViewportManager.ViewportToWorld(viewportPoint);
        }
    }
}