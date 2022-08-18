using Cysharp.Threading.Tasks;

namespace UI.Framework.ViewListeners
{
    public interface IInvokableViewListener : IViewListener
    {
        UniTaskCompletionSource OpenSource { get; }
        UniTaskCompletionSource CloseSource { get; }
    }
}