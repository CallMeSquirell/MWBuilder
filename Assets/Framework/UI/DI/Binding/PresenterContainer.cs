using System;
using System.Collections.Generic;
using UI.Framework.UI.Views.Impl;
using Zenject;

namespace UI.Framework.UI.DI.Binding
{
    public sealed class PresenterContainer : IPresenterContainer
    {
        private readonly DiContainer _container;

        private readonly Dictionary<Type, IPresenterBinding> _bindings = new();
        
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