using UI.Framework.UI.ViewListeners;

namespace UI.Framework.UI.Data
{
    public interface IViewData
    {
        IViewDefinition Definition { get; }
        IViewListener Listener { get; }
        object Payload { get; }
    }
}