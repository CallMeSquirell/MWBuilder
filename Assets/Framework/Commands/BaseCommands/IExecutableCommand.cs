using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Commands.Framework.Commands.BaseCommands
{
    public interface ICommand : IDisposable
    {
        
    }
    
    public interface IExecutableCommand : ICommand
    {
        UniTask Execute(CancellationToken cancellationToken = default);
    }
    
    public interface IExecutableCommand<T> : ICommand where T : ICommandPayload
    {
        UniTask Execute(T payload, CancellationToken cancellationToken = default);
    }
}