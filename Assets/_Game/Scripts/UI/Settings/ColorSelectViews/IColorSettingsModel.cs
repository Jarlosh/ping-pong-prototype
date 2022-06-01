using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Settings.ColorSelectViews
{
    public interface IColorSettingsModel
    {
        IEnumerable<Color> GetOptions();
        int SelectedIndex { get; set; }
        event Action<int> OnSelectionChangedEvent;
    }
}