using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Scripts.Game.Impl
{
    public class BaseState : IGameState
    {
        protected IGameStateMachine GameStateMachine { get; }

        protected BaseState(IGameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
        }
        
        public virtual UniTask Enter(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}