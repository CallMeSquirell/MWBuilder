using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AssetManagement.Framework.Configs
{
    public interface IConfigService
    {
        UniTask Initialize(CancellationToken cancellationToken);
        T Get<T>() where T : ScriptableObject;
    }
}