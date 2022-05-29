using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputAxis axis;
        [SerializeField] private Racket racket;
        [SerializeField] private float moveSpeed = 1;
        
        private void Update()
        {
            racket.SetVelocity(axis.Value, moveSpeed * ViewportManager.WorldWidth);
        }
    }
}