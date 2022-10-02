using System.Threading;
using Commands.Framework.BaseCommands;
using Cysharp.Threading.Tasks;
using Project.Scripts.Constants;
using Project.Scripts.Core.Services;
using UI.Framework.Managers;

namespace Project.Scripts.UI.Commands
{
    public class PauseCommand : Command, IPauseCommand
    {
        private readonly IPlayerService _playerService;
        private readonly IUIManager _uiManager;

        public PauseCommand(IPlayerService playerService, IUIManager uiManager)
        {
            _playerService = playerService;
            _uiManager = uiManager;
        }
        
        public async UniTask Execute(CancellationToken cancellationToken = default)
        {
            _playerService.StopTimer();
            _playerService.PlayerModel.Locked = true;

            await _uiManager.OpenView(ViewNames.Settings).Closed;
            
            _playerService.RunTimer();
            _playerService.PlayerModel.Locked = false;
        }
    }
}