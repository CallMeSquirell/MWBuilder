using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.Commands.BaseCommands;

namespace Framework.Commands.ExecutableQueue.Impl
{
    public class QueuedCommand : IQueuedCommand
    {
        private readonly ICommand _command;
        private readonly ICommandPayload _payload;

        public QueuedCommand(ICommand command, ICommandPayload payload = null)
        {
            _command = command;
            _payload = payload;
        }

        public UniTask Execute(CancellationToken cancellationToken)
        {
            return Invoke(cancellationToken);
        }
        
        private UniTask Invoke(CancellationToken cancellationToken)
        {
            switch (_command)
            {
                case IExecutableCommand<ICommandPayload> executableCommandWithPayload:
                    return executableCommandWithPayload.Execute(_payload, cancellationToken);
                case IExecutableCommand executableCommand:
                    return executableCommand.Execute(cancellationToken);
            }

            return UniTask.CompletedTask;
        }

        public void Dispose()
        {
            _command.Dispose();
        }
    }
}