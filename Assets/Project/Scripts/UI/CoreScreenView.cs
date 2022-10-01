using System;
using TMPro;
using UI.Framework.Views.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Framework.UI.Animations.Scripts.UI.Core.Views
{
    public class CoreScreenView : ScreenBaseView
    {
        public static event Action<int> StateChanged;
        
        [SerializeField] 
        private Button _changeStateButton;

        [SerializeField] 
        private TMP_InputField _inputField;

        [SerializeField] 
        private TextMeshProUGUI _timerText;
        
        protected override void Awake()
        {
            base.Awake();
           _changeStateButton.onClick.AddListener(OnStateChangedClicked);
        }

        private void OnStateChangedClicked()
        {
            StateChanged?.Invoke(int.Parse(_inputField.text));
        }

        public void UpdateTimer(int value)
        {
            _timerText.text = value.ToString();
        }
    }
}