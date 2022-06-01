using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Settings.ColorSelectViews
{
    public class ColorOptionsContainer : MonoBehaviour
    {
        [SerializeField] private Transform _optionsParent;
        [SerializeField] private GameObject _colorOptionPrefab;

        private Dictionary<int, ColorOptionPresenter> options = new Dictionary<int, ColorOptionPresenter>();
        
        private ColorOptionPresenter selectedOption;
        
        public event Action<int> OnClickedEvent;

        private void OnDestroy()
        {
            Clear();
        }

        public void AddOption(Color color, int optionIndex)
        {
            var go = Instantiate(_colorOptionPrefab, _optionsParent);
            var view = go.GetComponent<ColorOptionPresenter>();
            view.Init(color, optionIndex);
            view.OnClickedEvent += OnClick;
            options.Add(optionIndex, view);
        }

        private void RemoveOption(int index)
        {
            if (options.TryGetValue(index, out var view))
                return;
            
            if(view != null)
            {
                view.OnClickedEvent -= OnClick;
                Destroy(view.gameObject);
            }
            
            options.Remove(index);
        }

        private void OnClick(int index)
        {
            OnClickedEvent?.Invoke(index);
        }

        public void Clear()
        {
            var indices = options.Keys.ToArray();
            foreach (var index in indices) 
                RemoveOption(index);
        }

        public void Select(int index)
        {
            if(selectedOption != null)
                selectedOption.SetSelectionState(false);
            
            if (!options.TryGetValue(index, out var view))
                return;
            
            selectedOption = view;
            view.SetSelectionState(true);
        }
    }
}