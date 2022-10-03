using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UI.Framework.Views.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class DialogView : ManagedView
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _closButton;

        protected override void Awake()
        {
            
        }

        public void SetText(string payloadText)
        {
            _text.text = payloadText;
            StartAnimation().Forget();
            CloseAfterClick().Forget();
        }

        private async UniTask CloseAfterClick()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5));
            await _closButton.GetAsyncClickEventHandler().OnClickAsync();
            Close();
        }

        private async UniTask StartAnimation()
        {
            await _image.DOFade(1, 0.15f);
            await _text.DOFade(1, 0.2f);
        }
    }
}