using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Commands.Framework.Commands.ExecutableQueue
{
    public interface IQueuedCommand : IDisposable
    { 
        UniTask Execute(CancellationToken cancellationToken);
    }
}