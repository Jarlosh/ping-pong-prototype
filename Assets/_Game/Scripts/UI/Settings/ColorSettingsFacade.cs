using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.UI
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