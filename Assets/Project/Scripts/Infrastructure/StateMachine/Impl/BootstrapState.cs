using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Scripts.Game.Impl
{
    public class BootstrapState : BaseState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public override UniTask Enter(CancellationToken cancellationToken)
        {
            return _gameStateMachine.Enter<LoadingState>(cancellationToken);
        }
    }
}