using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UI.HUD
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private Button settingsButton;
        [SerializeField] private SettingsController settingsController;
        
        private void OnEnable()
        {
            settingsButton.onClick.AddListener(OnSettingsClicked);
        }
        
        private void OnDisable()
        {
            settingsButton.onClick.RemoveListener(OnSettingsClicked);
        }
        
        private void OnSettingsClicked()
        {
            settingsController.Open();
        }
    }
}