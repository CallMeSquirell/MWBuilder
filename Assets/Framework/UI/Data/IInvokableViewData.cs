using UI.Framework.UI.ViewListeners;

namespace UI.Framework.UI.Data
{
    public interface IInvokableViewData : IViewData
    {
        IInvokableViewListener InvokableListener { get; } 
    }
}