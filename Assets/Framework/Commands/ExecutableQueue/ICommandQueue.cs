using System;
using System.Threading;
using Commands.Framework.BaseCommands;

namespace Commands.Framework.ExecutableQueue
{
    public interface ICommandQueue : IDisposable
    {
        bool AutoExecute { get; set; }
        bool IsPlaying { get;}
        void Add<T>(ICommandPayload payload, int priority, CancellationToken cancellationToken = default) where T : Command, IExecutableCommand<ICommandPayload>;
        void Add<T>(int priority, CancellationToken cancellationToken = default) where T : Command, IExecutableCommand;
        void AddTrigger<T>(int priority, CancellationToken cancellationToken = default) where T : IExecutableCommand;
        void AddTrigger<T>(ICommandPayload payload, int priority, CancellationToken cancellationToken = default) where T : IExecutableCommand<ICommandPayload>;
        void Play(CancellationToken cancellationToken = default);
        void Stop();
    }
}