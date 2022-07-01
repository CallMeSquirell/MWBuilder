using Cysharp.Threading.Tasks;

namespace Framework.UI.Managers.ViewListeners
{
    public interface IInvokableViewListener : IViewListener
    {
        UniTaskCompletionSource OpenSource { get; }
        UniTaskCompletionSource CloseSource { get; }
    }
}