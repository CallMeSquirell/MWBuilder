using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Utils.Framework.Utils.Extensions;

namespace UI.Framework.UI.Views.Impl
{
    public class PopUpView : ManagedView, IPopUpView
    {
        public event Action CloseClicked;

        [SerializeField] private Button _closeButton;

        protected override void Awake()
        {
            base.Awake();
            if (_closeButton.NonNull())
            {
                _closeButton.onClick.AddListener(OnCloseButtonClicked);
            }
        }

        private void OnCloseButtonClicked()
        {
            CloseClicked?.Invoke();
        }

        protected virtual void OnDestroy()
        {
            if (_closeButton.NonNull())
            {
                _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            }
        }

#if PLATFORM_ANDROID
        public override UniTask AndroidButtonGoBack(CancellationToken cancellationToken)
        {
            return Close(cancellationToken: cancellationToken);
        }
#endif
    }
}