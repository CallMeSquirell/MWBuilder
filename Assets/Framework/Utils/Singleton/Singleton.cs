using Framework.Utils.Extensions;
using UnityEngine;

namespace Framework.Utils.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance => _instance;

        private static T _instance;
        
        private void Awake()
        {
            if (_instance.NonNull())
            {
                Destroy(Instance.gameObject);
            }

            _instance = this as T;
            DontDestroyOnLoad(Instance);
        }
    }
}