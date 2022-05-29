using UnityEngine;

namespace _Game.Scripts.UI
{
    public abstract class PlayerPrefItem<T> : ScriptableObject
    {
        [SerializeField] protected string key;

        public T Value
        {
            get => GetValue();
            set
            {
                if (Equals(Value, value))
                    return;
                SetValue(value);
            }
        }

        protected abstract void SetValue(T value);

        protected abstract T GetValue();
    }
}