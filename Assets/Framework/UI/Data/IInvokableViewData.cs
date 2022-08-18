using UI.Framework.ViewListeners;

namespace UI.Framework.Data
{
    public interface IInvokableViewData : IViewData
    {
        IInvokableViewListener InvokableListener { get; } 
    }
}