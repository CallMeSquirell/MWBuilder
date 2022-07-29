using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.ResourceManagement;
using Framework.Utils.Editor;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Game.Impl
{
    public class MetaState : BaseState
    {
        private readonly IAssetManager _assetManager;

        public MetaState(IGameStateMachine gameStateMachine, 
            IAssetManager assetManager) : base(gameStateMachine)
        {
            _assetManager = assetManager;
        }

        public override async UniTask Enter(CancellationToken cancellationToken)
        {
            await SceneManager.LoadSceneAsync(SceneNames.MetaScene.Path);
        }

        public override UniTask Exit(CancellationToken cancellationToken)
        {
            return base.Exit(cancellationToken);
        }
    }
}