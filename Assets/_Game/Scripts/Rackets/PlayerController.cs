using Tools.Scaling;
using Core.Rackets.Input;
using UnityEngine;

namespace Core.Rackets
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