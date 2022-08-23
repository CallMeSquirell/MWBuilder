using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace AssetManagement.Framework.Assets
{
    public class AssetManager : IAssetManager
    {
        public UniTask<T> LoadAsset<T>(string path, CancellationToken cancellationToken)
        {
            return Addressables.LoadAssetAsync<T>(path).ToUniTask(cancellationToken: cancellationToken);
        }

        public async UniTask<T> LoadPrefabForComponent<T>(string path, CancellationToken cancellationToken)
        {
            var asset = await LoadAsset<GameObject>(path, cancellationToken);
            if (!asset.TryGetComponent(out T component))
            {
                throw new Exception($"Failed to Load asset with key: {path}");
            }

            return component;
        }

        public UniTask<SceneInstance> LoadScene(string path)
        {
            return Addressables.LoadSceneAsync(path).ToUniTask();
        }

        public void Release<T>(T obj)
        {
            Addressables.Release(obj);
        }
    }
}