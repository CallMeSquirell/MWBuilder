using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Core.Cells.Mechanics;

namespace Project.Scripts.Core.Processors
{
    public abstract class BaseTakeProcessor<T> : ICardProcessor
    {
        UniTask ICardProcessor.Reveal(ICard card, CancellationToken cancellationToken)
        {
            if (card is T processableCard)
            {
                return InternalReveal(processableCard, cancellationToken);
            }
            return UniTask.CompletedTask;
        }

        UniTask ICardProcessor.Take(ICard card, CancellationToken cancellationToken)
        {
            if (card is T processableCard)
            {
                return InternalTake(processableCard, cancellationToken);
            }
            return UniTask.CompletedTask;
        }
        
        UniTask ICardProcessor.Use(ICard card, CancellationToken cancellationToken)
        {
            if (card is T processableCard)
            {
                return InternalUse(processableCard, cancellationToken);
            }
            return UniTask.CompletedTask;
        }

        protected abstract UniTask InternalTake(T processableCard, CancellationToken cancellationToken);
        protected abstract UniTask InternalReveal(T processableCard, CancellationToken cancellationToken);
        protected abstract UniTask InternalUse(T processableCard, CancellationToken cancellationToken);
    }
}