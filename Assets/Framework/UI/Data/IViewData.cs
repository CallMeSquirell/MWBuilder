using UI.Framework.ViewListeners;

namespace UI.Framework.Data
{
    public interface IViewData
    {
        IViewDefinition Definition { get; }
        IViewListener Listener { get; }
        object Payload { get; }
    }
}