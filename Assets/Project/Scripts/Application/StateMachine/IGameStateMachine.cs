using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Scripts.Game
{
    public interface IGameStateMachine
    {
        UniTask Enter<T>(CancellationToken cancellationToken = default) where T : class, IGameState;
    }
}