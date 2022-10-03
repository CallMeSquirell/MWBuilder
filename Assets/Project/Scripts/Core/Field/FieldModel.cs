using System;
using Commands.Framework.Core;
using Cysharp.Threading.Tasks;
using Framework.Timer;
using Project.Scripts.Constants;
using Project.Scripts.Core.Services;
using Project.Scripts.Meta.Input;
using Project.Scripts.UI;
using UI.Framework.Managers;

namespace Project.Scripts.Core
{
    public class FieldModel : IDisposable
    {
        private const string SecondTutorialText =
            "Did you see it? Apparently, the maze doesn't want the personalities to get to the end. In some places, the maze is changing!";

        private readonly IPlayerService _playerService;
        private readonly ICommandExecutor _commandExecutor;
        private readonly PortalsModel _portalsModel;
        private readonly IInputService _inputService;
        private readonly IUIManager _uiManager;
        private bool _dialogShown;

        public PortalsModel PortalsModel => _portalsModel;

        public FieldModel(IPlayerService playerService,
            ICommandExecutor commandExecutor,
            IUITutorialService iuiTutorialService,
            IInputService inputService,
            IActionTimer timer,
            IUIManager uiManager)
        {
            _inputService = inputService;
            _uiManager = uiManager;
            _playerService = playerService;
            _commandExecutor = commandExecutor;
            _portalsModel = new PortalsModel(playerService, _uiManager, iuiTutorialService, timer);
            _inputService.PressedKeyE.AddListener(OnEPressed);
        }

        private void OnEPressed(bool value)
        {
            if (value && _portalsModel.TeleportSpawnPoint != null)
            {
                _playerService.PlayerModel.Locked = true;
                _playerService.StopTimer();

                _playerService.PlayerModel.Teleport(_portalsModel.TeleportSpawnPoint.position);

                _playerService.PlayerModel.Locked = false;
                _playerService.RunTimer();
            }
        }

        public void StateChangeStarted()
        {
            _playerService.PlayerModel.Locked = true;
        }

        public void StateChangeEnded()
        {
            _playerService.PlayerModel.Locked = false;
        }

        public void Dispose()
        {
            _inputService.PressedKeyE.RemoveListener(OnEPressed);
        }

        public void PlayerEarnedFinish(PlayerView view)
        {
            _playerService.FinishPlayer(view);
        }

        public async UniTask ShowDialog()
        {
            if (_dialogShown)
            {
                return;
            }

            _playerService.StopTimer();
            _playerService.PlayerModel.Locked = true;

            await _uiManager.OpenView(ViewNames.DialogBubble, new DialogPayload()
            {
                Text = SecondTutorialText
            }).Closed;

            _playerService.RunTimer();
            _playerService.PlayerModel.Locked = false;
            _dialogShown = true;
        }
    }
}