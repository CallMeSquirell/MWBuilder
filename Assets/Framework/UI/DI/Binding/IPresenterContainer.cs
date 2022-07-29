using System;
using UI.Framework.UI.Views.Impl;

namespace UI.Framework.UI.DI.Binding
{
    public interface IPresenterContainer
    {
        IPresenterBinding BindView<T>() where T : ScreenBaseView;
        IPresenterBinding GetBinding(Type type);
    }
}