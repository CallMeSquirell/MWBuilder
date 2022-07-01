using System;
using Framework.UI.Managers.Layer;

namespace Framework.UI.Managers.Data
{
    [Serializable]
    public class ViewDefinition : IViewDefinition
    {
        private readonly string _name;
        private readonly string _prefabPath;
        private readonly WindowLayerEnum _layerName;

        public ViewDefinition(string name, WindowLayerEnum layerName, string prefabPath)
        {
            _name = name;
            _prefabPath = prefabPath;
            _layerName = layerName;
        }
        
        public string ResourcePath => _prefabPath;

        public WindowLayerEnum LayerName => _layerName;

        public string Name => _name;
    }
}