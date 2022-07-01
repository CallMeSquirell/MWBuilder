using System;

namespace Framework.UI.MVP.Views
{
    public interface IPopUpView : IManagedView
    {
        event Action CloseClicked;
    }
}