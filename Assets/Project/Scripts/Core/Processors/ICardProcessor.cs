using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Core.Cells.Mechanics;

namespace Project.Scripts.Core.Processors
{
    public interface ICardProcessor
    {
        UniTask Reveal(ICard card, CancellationToken cancellationToken);
        UniTask Take(ICard card, CancellationToken cancellationToken);
        UniTask Use(ICard card, CancellationToken cancellationToken);
    }
}