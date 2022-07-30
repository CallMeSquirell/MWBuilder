using System;
using System.Collections.Generic;
using UI.Framework.UI.Views;
using Zenject;

namespace UI.Framework.UI.DI.Binding
{
    public sealed class PresenterBinding : IPresenterBinding
    {
        private readonly IInstantiator _instantiator;
        private Type _presenterType;

        private readonly Dictionary<IScreenBaseView, IPresenter> _createdPresenter = new();

        public PresenterBinding(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void To<TPresenter>() where TPresenter : IPresenter<IScreenBaseView>
        {
            _presenterType = typeof(TPresenter);
        }

        public void CreatePresenter(IScreenBaseView screenBaseView, object payload = null)
        {
            var args = payload != null ? new[] {screenBaseView, payload} : new[] {screenBaseView};
            var presenter = (IPresenter) _instantiator.Instantiate(_presenterType, args);
            presenter.Initialise();
            _createdPresenter.Add(screenBaseView, presenter);
        }

        public void DestroyPresenter(IScreenBaseView screenBaseView)
        {
            if (_createdPresenter.TryGetValue(screenBaseView, out var presenter))
            {
                presenter.Dispose();
                _createdPresenter.Remove(screenBaseView);
            }
        }
    }
}