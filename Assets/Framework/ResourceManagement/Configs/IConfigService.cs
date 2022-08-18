using UnityEngine;

namespace AssetManagement.Framework.Configs
{
    public interface IConfigService
    {
        T Get<T>() where T : ScriptableObject;
    }
}