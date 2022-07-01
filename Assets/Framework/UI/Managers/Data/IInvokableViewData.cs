using Framework.UI.Managers.ViewListeners;

namespace Framework.UI.Managers.Data
{
    public interface IInvokableViewData : IViewData
    {
        IInvokableViewListener InvokableListener { get; } 
    }
}