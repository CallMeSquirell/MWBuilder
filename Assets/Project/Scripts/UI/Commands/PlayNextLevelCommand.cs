using System.Threading;
using Commands.Framework.BaseCommands;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework;
using Project.Scripts.Infrastructure.States;

namespace Project.Scripts.UI.Commands
{
    public class PlayNextLevelCommand : Command, IPlayNextLevelCommand
    {
        private readonly IGameStateMachine _gameStateMachine;

        public PlayNextLevelCommand(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public async UniTask Execute(CancellationToken cancellationToken = default)
        {
            await _gameStateMachine.Enter<CoreState>(cancellationToken);
        }
    }
}