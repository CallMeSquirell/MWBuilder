using System;
using UI.Framework.UI.Views.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Meta
{
    public class MetaScreenView : ScreenBaseView
    {
        public event Action PlayClicked;
        
        [SerializeField] private Button _playButton;

        private void Start()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
        }

        private void OnPlayClicked()
        {
            PlayClicked?.Invoke();
        }

        protected override void OnInteractableChanged(bool interactable)
        {
            base.OnInteractableChanged(interactable);
            _playButton.interactable = interactable;
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(OnPlayClicked);
        }
    }
}