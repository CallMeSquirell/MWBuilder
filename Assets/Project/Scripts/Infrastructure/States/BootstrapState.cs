using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Scripts.Game.Impl
{
    public class BootstrapState : BaseState
    {
        protected BootstrapState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override UniTask Enter(CancellationToken cancellationToken)
        {
            return GameStateMachine.Enter<LoadingState>(cancellationToken);
        }
    }
}