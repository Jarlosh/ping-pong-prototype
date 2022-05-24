using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Racket racket;
        [SerializeField] private float speed = 1;
        
        private float axis;

        private void Update()
        {
            axis = Input.GetAxis("Horizontal");
            
            // ok due axis threshold
            if (axis != 0) 
                Accelerate();
            else
                Decelerate();
        }

        private void Accelerate()
        {
            racket.Velocity = Vector3.right * (Mathf.Sign(axis) * speed * Time.deltaTime);
        }

        private void Decelerate()
        {
            racket.Velocity = Vector2.zero;
        }
    }
}