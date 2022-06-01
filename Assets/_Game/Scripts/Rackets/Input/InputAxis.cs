using UnityEngine;

namespace Core.Rackets.Input
{
    public enum AxisState
    {
        Negative = -1,
        Neutral = 0,
        Positive = 1
    }
    
    public class InputAxis : MonoBehaviour
    {
        [SerializeField] private float _value = 0;
        [SerializeField] private float _sensivity = 3;
        [SerializeField] private float _dead = 0.01f;
        private AxisState _state;
        
        public float Value => Mathf.Abs(_value) > _dead ? _value : 0;
        
        public AxisState State
        {
            get => _state;
            set
            {
                if (_state == value)
                    return;
                _state = value;
                if (_state != AxisState.Neutral)
                    Reset();
            }
        }

        private void Reset()
        {
            _value = 0;
        }

        private void Update()
        {
            var delta = (int) _state - _value;
            var step = Mathf.Sign(delta) * _sensivity * Time.deltaTime;
            _value += Mathf.Abs(step) > Mathf.Abs(delta) ? delta : step;
        }
    }
}