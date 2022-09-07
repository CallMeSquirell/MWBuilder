using System;
using System.Collections.Generic;
using System.Threading;
using AssetManagement.Framework.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AssetManagement.Framework.Configs
{
    public abstract class ConfigService : IConfigService
    {
        private readonly Dictionary<Type, ScriptableObject> _configs;
        private readonly IAssetManager _assetManager;

        protected ConfigService(IAssetManager assetManager)
        {
            _assetManager = assetManager;
            _configs = new Dictionary<Type, ScriptableObject>();
        }

        public UniTask Initialize(CancellationToken cancellationToken)
        {
            return LoadConfigs(cancellationToken);
        }
        
        protected async UniTask LoadConfig(string key, CancellationToken cancellationToken)
        {
            var config = await _assetManager.LoadAsset<ScriptableObject>(key, cancellationToken);
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
        
        protected abstract UniTask LoadConfigs(CancellationToken cancellationToken);
    }
}