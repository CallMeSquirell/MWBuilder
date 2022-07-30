using System.Threading;
using AssetManagement.Framework.ResourceManagement.Assets;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework.GameStateMachine;
using Project.Scripts.Constants;
using Project.Scripts.Infrastructure.Data;
using UI.Framework.UI.Managers;
using Utils.Framework.Utils.Editor;

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
            await _assetManager.LoadScene(SceneNames.MetaScene.Path);
            await _uiManager.OpenView(ViewNames.CoreScreen).Opened;
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}