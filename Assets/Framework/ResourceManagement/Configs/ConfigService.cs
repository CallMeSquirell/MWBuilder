using System;
using System.Collections.Generic;
using AssetManagement.Framework.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AssetManagement.Framework.Configs
{
    public class ConfigService : IConfigService, IInitializable
    {
        private Dictionary<Type, ScriptableObject> _configs;
        private IAssetManager _assetManager;

        public void Initialize()
        {
            _configs = new Dictionary<Type, ScriptableObject>();
        }

        private async UniTask LoadConfig(string key)
        {
            var config = await _assetManager.LoadAsset<ScriptableObject>(key);
            _configs.Add(config.GetType(), config);
        }
        
        public T Get<T>() where T : ScriptableObject
        {
            if (_configs.TryGetValue(typeof(T), out var config))
            {
                return (T) config;
            }

            return null;
        }
    }
}