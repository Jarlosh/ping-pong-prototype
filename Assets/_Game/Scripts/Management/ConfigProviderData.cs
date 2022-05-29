using System;
using Tools;
using UnityEngine;

namespace Core.Management
{
    [CreateAssetMenu(menuName = "SO/BallConfigProvider", fileName = "BallConfigProvider", order = 0)]
    public class ConfigProviderData : ScriptableObject
    {
        [SerializeField] private WeightedPicker<BallMoveConfig> moveConfigPicker;
        [SerializeField] private Color baseColor = Color.green;
            
        public BallConfig PickConfig()
        {
            return new BallConfig()
            {
                color = GetColor(),
                moveConfig = moveConfigPicker.Pick()
            };
        }

        private Color GetColor()
        {
            return baseColor;
        }
    }
}