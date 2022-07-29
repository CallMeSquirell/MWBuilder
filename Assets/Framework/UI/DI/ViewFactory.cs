using System.Threading;
using AssetManagement.Framework.ResourceManagement.Assets;
using Cysharp.Threading.Tasks;
using UI.Framework.UI.Data;
using UI.Framework.UI.Views.Impl;
using UnityEngine;
using Zenject;

namespace UI.Framework.UI.DI
{
    public class ViewFactory : IViewFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetManager _assetManager;

        public ViewFactory(IInstantiator instantiator,
            IAssetManager assetManager)
        {
            _instantiator = instantiator;
            _assetManager = assetManager;
        }

        public async UniTask<TView> Create<TView>(IViewDefinition data, Transform parent, CancellationToken  cancellationToken = default)
            where TView : ScreenBaseView
        {
            var prefab = await _assetManager.LoadPrefabForComponent<ScreenBaseView>(data.ResourcePath, cancellationToken);
            var result = _instantiator.InstantiatePrefabForComponent<TView>(prefab, parent);
            return result;
        }
    }
}