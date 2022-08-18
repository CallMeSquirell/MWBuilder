using System;

namespace UI.Framework.Views
{
    public interface IPopUpView : IManagedView
    {
        event Action CloseClicked;
    }
}