using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public interface IColorSettingsModel
    {
        IEnumerable<Color> GetOptions();
        int SelectedIndex { get; set; }
        event Action<int> OnSelectionChangedEvent;
    }
}