using Framework.UI.Managers.ViewListeners;

namespace Framework.UI.Managers.Data
{
    public interface IViewData
    {
        IViewDefinition Definition { get; }
        IViewListener Listener { get; }
        object Payload { get; }
    }
}