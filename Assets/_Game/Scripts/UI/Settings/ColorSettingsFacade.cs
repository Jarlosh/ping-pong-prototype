using System;
using System.Collections.Generic;
using Tools.UserPrefItems;
using UI.Settings.ColorSelectViews;
using UnityEngine;

namespace UI.Settings
{
    public class ColorSettingsFacade : IColorSettingsModel
    {
        private Color[] _colorOptions;

        private IntPlayerPrefItem prefItem;

        public ColorSettingsFacade(Color[] options, IntPlayerPrefItem prefItem)
        {
            _colorOptions = options;
            this.prefItem = prefItem;
        }
        
        public IEnumerable<Color> GetOptions() => _colorOptions;

        public int SelectedIndex
        {
            get => prefItem.Value;
            set
            {
                if (value == prefItem.Value)
                    return;
                prefItem.Value = value;
                OnSelectionChangedEvent?.Invoke(value);
            }
        }

        public event Action<int> OnSelectionChangedEvent;
    }
}