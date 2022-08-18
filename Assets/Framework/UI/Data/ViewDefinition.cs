using System;

namespace UI.Framework.Data
{
    [Serializable]
    public class ViewDefinition : IViewDefinition
    {
        private readonly string _name;
        private readonly string _prefabPath;
        private readonly int _layerIndex;

        public ViewDefinition(string name, int layerIndex, string prefabPath)
        {
            _name = name;
            _prefabPath = prefabPath;
            _layerIndex = layerIndex;
        }
        
        public string ResourcePath => _prefabPath;

        public int LayerIndex => _layerIndex;

        public string Name => _name;
    }
}