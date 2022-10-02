using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AssetManagement.Framework.Assets;
using Cysharp.Threading.Tasks;
using UI.Framework.Data;
using UI.Framework.Managers.Layers;
using UI.Framework.ViewListeners;
using UI.Framework.Views;
using UnityEngine;
using Zenject;

namespace UI.Framework.Managers
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
            var selectedLayer = _layers[viewDefinition.LayerIndex];
            var data = new ViewData(viewDefinition, payload);
            selectedLayer.PlaceView(data).Forget();

            foreach (var otherLayer in _layers.Where(layer => layer != selectedLayer && layer.Order > selectedLayer.Order))
            {
                otherLayer.Clear().Forget();
            }
            
            return data.Listener;
        }

        public IScreenBaseView GetView(IViewDefinition viewDefinition)
        {
            return (from layer in _layers
                where layer.PlacedViewData.Definition.Name.Equals(viewDefinition.Name)
                select layer.PlacedView).FirstOrDefault();
        }

        private void OnViewPlaced(WindowLayer layer)
        {
            SetFocus(layer);
        }

        private void OnLayerCleared(WindowLayer layer)
        {
            for (int i = _layers.IndexOf(layer); i >= 0; i--)
            {
                if (_layers[0].PlacedViewData != null)
                {
                    SetFocus(layer);
                    return;
                }
            }
        }

        private void SetFocus(WindowLayer layer)
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