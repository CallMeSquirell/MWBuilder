using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Scripts.Game.Impl
{
    public class BaseState : IGameState
    {
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