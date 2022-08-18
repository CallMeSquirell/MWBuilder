using AssetManagement.Framework.Assets;
using UnityEngine;
using Zenject;

namespace UI.Framework.Views.Impl
{
    public class BaseViewBehaviour : MonoBehaviour
    {
        private IAssetManager _assetManager;

        protected IAssetManager AssetManager => _assetManager;
        
        [Inject]
        private void Construct(IAssetManager assetManager)
        {
            _assetManager = assetManager;
        }
    }
}