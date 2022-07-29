using UI.Framework.UI.ViewListeners;

namespace UI.Framework.UI.Data
{
    public class ViewData : IInvokableViewData
    {
        public IViewDefinition Definition { get; }
        public object Payload { get; }
        public IInvokableViewListener InvokableListener { get; }
        public IViewListener Listener => InvokableListener;
        
        public ViewData(IViewDefinition definition,
            object payload = null)
        {
            Definition = definition;
            InvokableListener = new ViewListener();
            Payload = payload;
        }
    }
}