using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Framework.ResourceManagement
{
    public interface IAssetManager
    {
        UniTask<T> LoadAsset<T>(string path, CancellationToken cancellationToken = default);
        UniTask<T> LoadPrefabForComponent<T>(string path, CancellationToken cancellationToken = default);
        void Release<T>(T obj);
        UniTask LoadScene(string path);
    }
}