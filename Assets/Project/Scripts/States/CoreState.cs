using System.Linq;
using System.Threading;
using AssetManagement.Framework.Assets;
using Cysharp.Threading.Tasks;
using Framework.Timer;
using GameStateMachine.Framework;
using Project.Scripts.Constants;
using Project.Scripts.Core;
using Project.Scripts.Core.Services;
using UI.Framework.Managers;
using UnityEngine;
using Utils.Framework.Editor;
using Utils.Framework.Extensions;
using Zenject;

namespace Project.Scripts.Infrastructure.States
{
    public class CoreState : IGameState
    {
        private readonly IAssetManager _assetManager;
        private readonly IUIManager _uiManager;
        private readonly IInstantiator _instantiator;
        private readonly IPlayerService _playerService;
        private FieldView _fieldView;
        private FieldModel _fieldModel;

        public CoreState(IAssetManager assetManager, IUIManager uiManager, IInstantiator instantiator, IPlayerService playerService)
        {
            _assetManager = assetManager;
            _uiManager = uiManager;
            _instantiator = instantiator;
            _playerService = playerService;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            var scene = await _assetManager.LoadScene(SceneNames.GameScene.Path);
            await _uiManager.OpenView(ViewNames.CoreScreen).Opened;
            
            var timer = new ActionTimer(10, 1);

            _fieldView = scene.Scene.FindComponentInRootObjects<FieldView>();
            _fieldModel = _instantiator.Instantiate<FieldModel>(new []{timer});
            _fieldView.Model = _fieldModel;
            
            var players = Object.FindObjectOfType<PlayerHandlerView>().Players;
            _playerService.Initialize(players, timer);
            _playerService.RunTimer();
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            _fieldView.Model = null;
            _fieldModel.Dispose();
            _playerService.StopTimer();
            return UniTask.CompletedTask;
        }
    }
}