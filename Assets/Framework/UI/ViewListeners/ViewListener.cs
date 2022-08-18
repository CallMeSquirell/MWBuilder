using Cysharp.Threading.Tasks;

namespace UI.Framework.ViewListeners
{
    public class ViewListener : IInvokableViewListener
    {
        public UniTask Opened => OpenSource.Task;
        public UniTask Closed => CloseSource.Task;

        public UniTaskCompletionSource OpenSource { get; }

        public UniTaskCompletionSource CloseSource { get; }

        public ViewListener()
        {
            OpenSource = new UniTaskCompletionSource();
            CloseSource = new UniTaskCompletionSource();
        }
    }
}