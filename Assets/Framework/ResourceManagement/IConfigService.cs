using UnityEngine;

namespace Framework.ResourceManagement
{
    public interface IConfigService
    {
        T Get<T>() where T : ScriptableObject;
    }
}