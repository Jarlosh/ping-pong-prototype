using System.Linq;
using Tools.UserPrefItems;
using UnityEngine;

namespace UI.Settings.ColorSelectViews
{
    public class ColorSelectionPresenter : MonoBehaviour
    {
        [SerializeField] private ColorOptionsContainer optionContainer;
        [SerializeField] private IntPlayerPrefItem prefItem;
        [SerializeField] private ColorOptionsData colorOptions;

        private IColorSettingsModel model;
        private Color[] options;
        
        private void Start()
        {
            SetModel(MakeModel());
            optionContainer.OnClickedEvent += OnOptionClick;
            InitOptions();
        }

        private ColorSettingsFacade MakeModel()
        {
            // temporal
            return new ColorSettingsFacade(colorOptions.Options, prefItem);
        }

        public void SetModel(IColorSettingsModel model)
        {
            this.model = model;
            model.OnSelectionChangedEvent += OnIndexChanged;
        }

        private void OnIndexChanged(int index)
        {
            optionContainer.Select(index);
        }

        private void InitOptions()
        {
            optionContainer.Clear();
            options = model.GetOptions().ToArray();
            for (int i = 0; i < options.Length; i++) 
                optionContainer.AddOption(options[i], i);
            optionContainer.Select(model.SelectedIndex);
        }

        private void OnOptionClick(int index)
        {
            model.SelectedIndex = index;
        }
    }
}