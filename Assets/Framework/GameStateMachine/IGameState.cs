using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameStateMachine.Framework
{
    public interface IGameState
    {
        UniTask Enter(CancellationToken cancellationToken);
        UniTask Exit(CancellationToken cancellationToken);
    }
}