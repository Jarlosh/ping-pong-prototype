using UnityEngine;

namespace UI.Settings
{
    [CreateAssetMenu(menuName = "SO/ColorOptionsData", fileName = "ColorOptionsData", order = 0)]
    public class ColorOptionsData : ScriptableObject
    {
        [field: SerializeField] public Color[] Options { get; set; } 
    }
}