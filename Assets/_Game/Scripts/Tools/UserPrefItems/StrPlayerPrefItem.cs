using UnityEngine;

namespace Tools.UserPrefItems
{
    [CreateAssetMenu(menuName = "SO/Prefs/StrPlayerPrefItem", fileName = "StrPlayerPrefItem", order = 0)]
    public class StrPlayerPrefItem : PlayerPrefItem<string>
    {
        protected override void SetValue(string value) 
        {
            PlayerPrefs.SetString(key, value);
        }

        protected override string GetValue()
        {
            return PlayerPrefs.GetString(key);
        }
    }
}