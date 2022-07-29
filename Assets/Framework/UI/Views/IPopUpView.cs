using System;

namespace UI.Framework.UI.Views
{
    public interface IPopUpView : IManagedView
    {
        event Action CloseClicked;
    }
}