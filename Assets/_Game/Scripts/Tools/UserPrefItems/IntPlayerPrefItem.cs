using UnityEngine;

namespace _Game.Scripts.UI
{
    [CreateAssetMenu(menuName = "SO/Prefs/IntPlayerPrefItem", fileName = "IntPlayerPrefItem", order = 0)]
    public class IntPlayerPrefItem : PlayerPrefItem<int>
    {
        [SerializeField] private int defaultValue;

        protected override void SetValue(int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        protected override int GetValue()
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }
}