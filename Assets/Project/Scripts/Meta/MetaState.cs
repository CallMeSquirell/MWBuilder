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
    public class MetaState : IGameState
    {
        private readonly MetaContext _metaContext;
        private readonly IAssetManager _assetManager;
        private readonly IUIManager _uiManager;

        public MetaState(MetaContext metaContext, IAssetManager assetManager, IUIManager uiManager)
        {
            _metaContext = metaContext;
            _assetManager = assetManager;
            _uiManager = uiManager;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            await _assetManager.LoadScene(SceneNames.MetaScene.Path);
            await _uiManager.OpenView(ViewNames.MetaScreen).Opened;
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}