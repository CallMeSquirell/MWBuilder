using System;
using UI.Framework.Views.Impl;

namespace UI.Framework.DI.Binding
{
    public interface IPresenterContainer
    {
        IPresenterBinding BindView<T>() where T : ScreenBaseView;
        IPresenterBinding GetBinding(Type type);
    }
}