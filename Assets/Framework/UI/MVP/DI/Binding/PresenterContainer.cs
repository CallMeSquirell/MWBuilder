using System;
using System.Collections.Generic;
using Framework.UI.MVP.Views.Impl;
using Zenject;

namespace Framework.UI.MVP.DI.Binding
{
    public sealed class PresenterContainer : IPresenterContainer
    {
        private readonly DiContainer _container;

        private readonly Dictionary<Type, IPresenterBinding> _bindings
            = new Dictionary<Type, IPresenterBinding>();
        
        public PresenterContainer(DiContainer container)
        {
            _container = container;
        }
        
        public IPresenterBinding BindView<T>() where T : ScreenBaseView
        {
            var presenterBinding = new PresenterBinding(_container);
            _bindings.Add(typeof(T), presenterBinding);
            return presenterBinding;
        }
        
        public IPresenterBinding GetBinding(Type type)
        {
            return _bindings.TryGetValue(type, out var value) ? value : null;
        }
    }
}