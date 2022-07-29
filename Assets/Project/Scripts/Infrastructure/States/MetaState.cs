using System.Threading;
using AssetManagement.Framework.ResourceManagement.Assets;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework.GameStateMachine;
using Utils.Framework.Utils.Editor;

namespace Project.Scripts.Infrastructure.States
{
    public class MetaState : IGameState
    {
        private readonly MetaContext _metaContext;
        private readonly IAssetManager _assetManager;

        public MetaState(MetaContext metaContext, IAssetManager assetManager)
        {
            _metaContext = metaContext;
            _assetManager = assetManager;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            await _assetManager.LoadScene(SceneNames.MetaScene.Path);
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}