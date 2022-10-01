﻿using System.Threading;
using AssetManagement.Framework.Assets;
using AssetManagement.Framework.Configs;
using Cysharp.Threading.Tasks;

namespace Project.Scripts.Infrastructure.Services
{
    public class MMBuilderConfigService : ConfigService
    {
        public MMBuilderConfigService(IAssetManager assetManager) : base(assetManager)
        {
        }

        protected override async UniTask LoadConfigs(CancellationToken cancellationToken)
        {
        }
    }
}