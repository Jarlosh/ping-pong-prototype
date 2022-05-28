using System;
using UnityEngine;

namespace Core
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