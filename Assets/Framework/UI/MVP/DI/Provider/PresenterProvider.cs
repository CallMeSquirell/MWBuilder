using System;
using System.Linq;
using Framework.UI.MVP.DI.Binding;
using Framework.UI.MVP.Views;
using Framework.UI.MVP.Views.Impl;
using UnityEngine;

namespace Framework.UI.MVP.DI.Provider
{
    public sealed class PresenterProvider : IPresenterProvider
    {
        private readonly IPresenterContainer _presenterContainer;

        public PresenterProvider(IPresenterContainer presenterContainer)
        {
            _presenterContainer = presenterContainer;
        }

        public void ProvideIncludeSubViesTo(IScreenBaseView screenBaseView, object payload = null)
        {
            var views = ((ScreenBaseView) screenBaseView).GetComponentsInChildren<ScreenBaseView>(true);
            ProvideTo(screenBaseView, payload);
            foreach (var subView in views.Skip(1))
            {
                ProvideTo(subView, null);
            }
        }
        
        public void ProvideTo(
            IScreenBaseView screenBaseView,
            object payload)
        {
            Type viewType = screenBaseView.GetType();
            var binding = _presenterContainer.GetBinding(viewType);
            if (binding != null)
            {
                binding.CreatePresenter(screenBaseView, payload);
            }
            else
            {
                Debug.LogError($"Zenject has no binding for {viewType}");
            }
        }

        public void DisposePresenterFor(IScreenBaseView screenBaseView)
        {
            Type viewType = screenBaseView.GetType();
            _presenterContainer.GetBinding(viewType).DestroyPresenter(screenBaseView);
        }
    }
}