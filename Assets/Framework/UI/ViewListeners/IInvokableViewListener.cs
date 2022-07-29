using Cysharp.Threading.Tasks;

namespace UI.Framework.UI.ViewListeners
{
    public interface IInvokableViewListener : IViewListener
    {
        UniTaskCompletionSource OpenSource { get; }
        UniTaskCompletionSource CloseSource { get; }
    }
}