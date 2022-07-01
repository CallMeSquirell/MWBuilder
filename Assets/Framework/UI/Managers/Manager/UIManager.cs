using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.ResourceManagement;
using Framework.UI.Managers.Data;
using Framework.UI.Managers.Exceptions;
using Framework.UI.Managers.Layer;
using Framework.UI.Managers.ViewListeners;
using Framework.UI.MVP.Views;
using UnityEngine;
using Zenject;

namespace Framework.UI.Managers.Manager
{
    public class UIManager : IUIManager
    {
        private const string UIRootKey = "UIRoot";
        
        private readonly IAssetManager _assetManager;
        private readonly IInstantiator _instantiator;

        private List<WindowLayer> _layers;
        private GameObject _root;

        public UIManager(IAssetManager assetManager, IInstantiator instantiator)
        {
            _assetManager = assetManager;
            _instantiator = instantiator;
        }

        public async UniTask Initialise(CancellationToken cancellationToken)
        {
            var rootPrefab = await _assetManager.LoadAsset<GameObject>(UIRootKey, cancellationToken);
            _root = _instantiator.InstantiatePrefab(rootPrefab);
            _layers = _root.GetComponentsInChildren<WindowLayer>()
                .OrderBy(layer => layer.Order)
                .ToList();
            _layers.ForEach(layer =>
            {
                layer.Cleared += OnLayerCleared;
                layer.ViewPlaced += OnViewPlaced;
            });
        }

        public IViewListener OpenView(IViewDefinition viewDefinition, object payload)
        {
            
            for (int i = _layers.Count - 1; i >= 0; i--)
            {
                var layer = _layers[i];
                
                if (layer.LayerType == viewDefinition.LayerName)
                {
                    
                    var data = new ViewData(viewDefinition, payload);
                    layer.PlaceView(data).Forget();
                    
                    return data.Listener;
                }
                
                layer.Clear().Forget();
            }

            throw new NoSuchLayerException();
        }

        public IScreenBaseView GetView(IViewDefinition viewDefinition)
        {
            return (from layer in _layers where layer.PlacedViewData.Definition.Name.Equals(viewDefinition.Name) 
                select layer.PlacedView).FirstOrDefault();
        }
        
        private void OnViewPlaced(WindowLayer layer)
        {
            UpdateFocus(layer);
        }
        
        private void OnLayerCleared(WindowLayer layer)
        {
            UpdateFocus(layer);
        }

        private void UpdateFocus(WindowLayer layer)
        {
            layer.SetFocus(true);
            _layers.Where(l => layer != l).ToList().ForEach(l => l.SetFocus(false));
        }

        public void DeInitialise()
        {
            _layers.ForEach(layer =>
            {
                layer.Cleared -= OnLayerCleared;
                layer.ViewPlaced -= OnViewPlaced;
            });
            _layers.Clear();
            _assetManager.Release(_root);
        }
    }
}