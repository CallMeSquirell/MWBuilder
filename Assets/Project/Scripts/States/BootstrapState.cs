using System.Threading;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework;

namespace Project.Scripts.Infrastructure.States
{
    public class BootstrapState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;

        protected BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public UniTask Enter(CancellationToken cancellationToken)
        {
            return _gameStateMachine.Enter<LoadingState>(cancellationToken);
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}