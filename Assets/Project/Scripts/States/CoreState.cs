using System.Linq;
using System.Threading;
using AssetManagement.Framework.Assets;
using Cysharp.Threading.Tasks;
using Framework.Timer;
using GameStateMachine.Framework;
using Project.Scripts.Constants;
using Project.Scripts.Core;
using Project.Scripts.Core.Services;
using Project.Scripts.UI;
using UI.Framework.Managers;
using UnityEngine;
using Utils.Framework.Editor;
using Utils.Framework.Extensions;
using Zenject;

namespace Project.Scripts.Infrastructure.States
{
    public class CoreState : IGameState
    {
        private const string FirstTutorialText = "Hello player! Under your control turned out to be four personalities of one person. To help the hero deal with his problems, you must bring all the personalities together in the center of this maze. But be careful, personalities are unstable and change EVERY 10 SECONDS! Good luck!";
        private readonly IAssetManager _assetManager;
        private readonly IUIManager _uiManager;
        private readonly IInstantiator _instantiator;
        private readonly IPlayerService _playerService;
        private FieldView _fieldView;
        private FieldModel _fieldModel;

        public CoreState(IAssetManager assetManager, IUIManager uiManager, IInstantiator instantiator,
            IPlayerService playerService)
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
            _fieldModel = _instantiator.Instantiate<FieldModel>(new[] {timer});
            _fieldView.Model = _fieldModel;

            var players = Object.FindObjectOfType<PlayerHandlerView>().Players;
            _playerService.Initialize(players, timer);
            _playerService.RunTimer();

            ShowDialog().Forget();
        }

        private async UniTask ShowDialog()
        {
            _playerService.StopTimer();
            _playerService.PlayerModel.Locked = true;

            await _uiManager.OpenView(ViewNames.DialogBubble, new DialogPayload()
            {
                Text = FirstTutorialText
            }).Closed;

            _playerService.RunTimer();
            _playerService.PlayerModel.Locked = false;
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