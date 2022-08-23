using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace AssetManagement.Framework.Assets
{
    public interface IAssetManager
    {
        UniTask<T> LoadAsset<T>(string path, CancellationToken cancellationToken = default);
        UniTask<T> LoadPrefabForComponent<T>(string path, CancellationToken cancellationToken = default);
        void Release<T>(T obj);
        UniTask<SceneInstance> LoadScene(string path);
    }
}