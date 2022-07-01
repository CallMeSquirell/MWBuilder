using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Scripts.Game
{
    public interface IGameState
    {
        UniTask Enter(CancellationToken cancellationToken);
        UniTask Exit(CancellationToken cancellationToken);
    }
}