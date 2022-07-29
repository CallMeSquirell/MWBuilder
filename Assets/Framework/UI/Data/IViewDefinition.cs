using UI.Framework.UI.Managers.Layers;

namespace UI.Framework.UI.Data
{
    public interface IViewDefinition
    {
        string ResourcePath { get; }
        string Name { get; }

        int LayerIndex { get; }
    }
}