using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Scripts.Game.Impl
{
    public class BootstrapState : IGameState
    {
        
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