using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings.ColorSelectViews
{
    public class ColorOptionPresenter : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image colorPreview;
        [SerializeField] private GameObject selection;
        private int index;
        
        public event Action<int> OnClickedEvent;

        private void Awake()
        {
            selection.SetActive(false);
            button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            OnClickedEvent?.Invoke(index);
        }

        public void Init(Color color, int optionIndex)
        {
            colorPreview.color = color;
            index = optionIndex;
        }

        public void SetSelectionState(bool state)
        {
            selection.SetActive(state);
        }
    }
}