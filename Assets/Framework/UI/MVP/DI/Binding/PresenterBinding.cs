using System;
using System.Collections.Generic;
using Framework.UI.MVP.Views;
using Zenject;

namespace Framework.UI.MVP.DI.Binding
{
    public sealed class PresenterBinding : IPresenterBinding
    {
        private readonly IInstantiator _instantiator;
        private Type _presenterType;

        private readonly Dictionary<IScreenBaseView, IPresenter> _createdPresenter 
            = new Dictionary<IScreenBaseView, IPresenter>();

        public PresenterBinding(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void To<P>() where P : IPresenter<IScreenBaseView>
        {
            _presenterType = typeof(P);
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