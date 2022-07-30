using System.Threading;
using Commands.Framework.Commands.BaseCommands;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework.GameStateMachine;
using Project.Scripts.Infrastructure.Data;
using Project.Scripts.Infrastructure.States;

namespace Project.Scripts.UI.Meta
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
            var context = new CoreContext();
            await _gameStateMachine.Enter<CoreState>(context, cancellationToken);
        }
    }
}