using Core.Ball;
using Tools.UserPrefItems;
using UI.Settings;
using UnityEngine;

namespace Management
{
    [CreateAssetMenu(menuName = "SO/BallConfigProvider", fileName = "BallConfigProvider", order = 0)]
    public class ConfigProviderData : ScriptableObject
    {
        [SerializeField] private ColorOptionsData colorOptions;
        [SerializeField] private IntPlayerPrefItem colorPlayerPrefItem;
        
        [SerializeField] private WeightedPicker<BallMoveConfig> moveConfigPicker;

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
            return colorOptions.Options[colorPlayerPrefItem.Value];
        }
    }
}