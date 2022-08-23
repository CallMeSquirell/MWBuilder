using System.Linq;
using System.Threading;
using AssetManagement.Framework.Assets;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework;
using Project.Scripts.Constants;
using Project.Scripts.Core;
using Project.Scripts.Infrastructure.Data;
using UI.Framework.Managers;
using Utils.Framework.Editor;
using Utils.Framework.Extensions;

namespace Project.Scripts.Infrastructure.States
{
    public class CoreState : IGameState
    {
        private readonly CoreContext _coreContext;
        private readonly IAssetManager _assetManager;
        private readonly IUIManager _uiManager;

        public CoreState(CoreContext coreContext, IAssetManager assetManager, IUIManager uiManager)
        {
            _coreContext = coreContext;
            _assetManager = assetManager;
            _uiManager = uiManager;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            var scene = await _assetManager.LoadScene(SceneNames.GameScene.Path);
            await _uiManager.OpenView(ViewNames.CoreScreen).Opened;
            var levelView = scene.Scene.FindComponentInRootObjects<LevelView>();
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}