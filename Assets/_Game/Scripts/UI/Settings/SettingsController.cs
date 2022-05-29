using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private GameObject holder;
        [SerializeField] private Button closeButton;

        private bool IsOpen => holder.activeInHierarchy;

        private void OnEnable()
        {
            closeButton.onClick.AddListener(Close);
        }
        
        private void OnDisable()
        {
            closeButton.onClick.RemoveListener(Close);
        }

        public void Close()
        {
            SetOpen(false);
        }

        public void Open()
        {
            SetOpen(true);
        }

        private void SetOpen(bool value)
        {
            if (IsOpen == value)
                return;
            gameObject.SetActive(value);   
        }
    }
}