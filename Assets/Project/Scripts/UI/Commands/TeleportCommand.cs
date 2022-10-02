using System.Threading;
using Commands.Framework.BaseCommands;
using Cysharp.Threading.Tasks;
using Project.Scripts.Core.Services;

namespace Project.Scripts.UI.Commands
{
    public class TeleportCommand : Command, ITeleportCommand
    {
        private readonly IPlayerService _service;

        public TeleportCommand(IPlayerService service)
        {
            _service = service;
        }
        
        public async UniTask Execute(TeleportCommandPayload payload, CancellationToken cancellationToken = default)
        {
            _service.PlayerModel.Locked = true;
            _service.StopTimer();

            _service.PlayerModel.Teleport(payload.Position);
            await UniTask.CompletedTask;
            
            _service.PlayerModel.Locked = false;
            _service.RunTimer();
        }
    }
}