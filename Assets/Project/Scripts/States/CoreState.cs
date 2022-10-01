using System.Linq;
using System.Threading;
using AssetManagement.Framework.Assets;
using Cysharp.Threading.Tasks;
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
        private readonly IPlayerChangeService _playerChangeService;
        private FieldView _fieldView;
        private FieldModel _fieldModel;

        public CoreState(IAssetManager assetManager, IUIManager uiManager, IInstantiator instantiator, IPlayerChangeService playerChangeService)
        {
            _assetManager = assetManager;
            _uiManager = uiManager;
            _instantiator = instantiator;
            _playerChangeService = playerChangeService;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            var scene = await _assetManager.LoadScene(SceneNames.GameScene.Path);
            await _uiManager.OpenView(ViewNames.CoreScreen).Opened;

            _fieldView = scene.Scene.FindComponentInRootObjects<FieldView>();
            _fieldModel = _instantiator.Instantiate<FieldModel>();
            _fieldView.Model = _fieldModel;

            var players = Object.FindObjectsOfType<PlayerView>().ToList();
            _playerChangeService.Initialize(players);
            _playerChangeService.Run();
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            _playerChangeService.Stop();
            return UniTask.CompletedTask;
        }
    }
}