using System.Threading;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework.GameStateMachine;
using Project.Scripts.Infrastructure.States;

namespace Project.Scripts.Game.Impl
{
    public class CoreState : IGameState
    {
        private readonly CoreContext _coreContext;

        public CoreState(CoreContext coreContext)
        {
            _coreContext = coreContext;
        }

        public UniTask Enter(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}