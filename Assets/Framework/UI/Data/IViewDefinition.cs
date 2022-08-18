namespace UI.Framework.Data
{
    public interface IViewDefinition
    {
        string ResourcePath { get; }
        string Name { get; }

        int LayerIndex { get; }
    }
}