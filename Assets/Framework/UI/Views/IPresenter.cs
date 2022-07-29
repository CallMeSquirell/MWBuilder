using System;

namespace UI.Framework.UI.Views
{
    public interface IPresenter : IDisposable
    {
        void Initialise();
    }

    public interface IPresenter<out T> : IPresenter where T : IScreenBaseView
    {
    }
}