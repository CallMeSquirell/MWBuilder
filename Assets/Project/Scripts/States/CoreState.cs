using System.Threading;
using AssetManagement.Framework.Assets;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework;
using Project.Scripts.Constants;
using Project.Scripts.Core;
using Project.Scripts.Infrastructure.Data;
using UI.Framework.Managers;
using Utils.Framework.Editor;
using Zenject;

namespace Project.Scripts.Infrastructure.States
{
    public class CoreState : IGameState
    {
        private readonly CoreContext _coreContext;
        private readonly IAssetManager _assetManager;
        private readonly IUIManager _uiManager;
        private readonly IInstantiator _instantiator;
        private LevelView _levelView;
        private LevelModel _levelModel;

        public CoreState(CoreContext coreContext, IAssetManager assetManager, IUIManager uiManager, IInstantiator instantiator)
        {
            _coreContext = coreContext;
            _assetManager = assetManager;
            _uiManager = uiManager;
            _instantiator = instantiator;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            await _assetManager.LoadScene(SceneNames.GameScene.Path);
            await _uiManager.OpenView(ViewNames.CoreScreen).Opened;
            var levelPrefab = await _assetManager.LoadPrefabForComponent<LevelView>(LevelView.Key, cancellationToken);
            _levelView = _instantiator.InstantiatePrefabForComponent<LevelView>(levelPrefab);
            _levelModel = new LevelModel();
            _levelModel.Initialize(_coreContext.LevelConfig);
            _levelView.Data = _levelModel;
            
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}