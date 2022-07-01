using Framework.UI.Managers.Layer;

namespace Framework.UI.Managers.Data
{
    public interface IViewDefinition
    {
        string ResourcePath { get; }
        string Name { get; }

        WindowLayerEnum LayerName { get; }
    }
}