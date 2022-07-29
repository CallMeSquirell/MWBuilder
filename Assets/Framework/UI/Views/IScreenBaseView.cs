using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace UI.Framework.UI.Views
{
    public interface IScreenBaseView
    {
        event Action<bool> FocusChanged;
        event Action Closed;
        bool Interactable { set; }
        UniTask Open(CancellationToken cancellationToken = default);
        UniTask Close(bool withAnimation = true, CancellationToken cancellationToken = default);
        bool IsFocused { get;}
    }
}