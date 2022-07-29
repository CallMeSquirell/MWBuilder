using UnityEngine;

namespace AssetManagement.Framework.ResourceManagement.Configs
{
    public interface IConfigService
    {
        T Get<T>() where T : ScriptableObject;
    }
}