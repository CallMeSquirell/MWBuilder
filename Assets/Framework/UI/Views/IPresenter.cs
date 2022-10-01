using System;

namespace UI.Framework.Views
{
    public interface IPresenter : IDisposable
    {
        void Initialize();
    }

    public interface IPresenter<out T> : IPresenter where T : IScreenBaseView
    {
    }
}