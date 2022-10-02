using System;
using Commands.Framework.Core;
using Cysharp.Threading.Tasks;
using Framework.Timer;
using Project.Scripts.Core.Services;
using Project.Scripts.Meta.Input;
using Project.Scripts.UI.Commands;

namespace Project.Scripts.Core
{
    public class FieldModel : IDisposable
    {
        private readonly IPlayerService _service;
        private readonly ICommandExecutor _commandExecutor;
        private readonly PortalsModel _portalsModel;
        private readonly IInputService _inputService;

        public PortalsModel PortalsModel => _portalsModel;

        public FieldModel(IPlayerService service, 
            ICommandExecutor commandExecutor,
            IUITutorialService iuiTutorialService, 
            IInputService inputService, 
            IActionTimer timer)
        {
            _inputService = inputService;
            _service = service;
            _commandExecutor = commandExecutor;
            _portalsModel = new PortalsModel(iuiTutorialService, timer);
            _inputService.PressedKeyE.AddListener(OnEPressed);
        }

        private void OnEPressed(bool value)
        {
            if (value && _portalsModel.TeleportSpawnPoint != null)
            {
                _service.PlayerModel.Locked = true;
                _service.StopTimer();

                _service.PlayerModel.Teleport(_portalsModel.TeleportSpawnPoint.position);

                _service.PlayerModel.Locked = false;
                _service.RunTimer();
            }
        }

        public void StateChangeStarted()
        {
            _service.PlayerModel.Locked = true;
        }

        public void StateChangeEnded()
        {
            _service.PlayerModel.Locked = false;
        }

        public void Dispose()
        {
            _inputService.PressedKeyE.RemoveListener(OnEPressed);
        }
    }
}