using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class PlayerRacket : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private Rigidbody2D visualRb;
        
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
            visualRb.velocity = Vector3.right * (Mathf.Sign(axis) * speed * Time.deltaTime);
        }

        private void Decelerate()
        {
            visualRb.velocity = Vector2.zero;
        }
    }
}