using Commands.Framework.BaseCommands;
using Commands.Framework.Exception;
using Cysharp.Threading.Tasks;

namespace Commands.Framework.Core.Impl
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandBinder _commandBinder;
        private readonly ICommandFactory _commandFactory;

        public CommandExecutor(ICommandBinder commandBinder, 
            ICommandFactory commandFactory)
        {
            _commandBinder = commandBinder;
            _commandFactory = commandFactory;
        }

        public UniTask Execute<T>() where T : ICommand
        {
            if (_commandBinder.TryGetBind<T>(out ICommandBinding binding) && 
                _commandFactory.Create(binding.Info) is IExecutableCommand executableCommand)
            {
                return executableCommand.Execute();
            }
            throw new NoSuchCommandException();
        }
        
        public UniTask Execute<T>(ICommandPayload payload) where T : ICommand
        {
            if (_commandBinder.TryGetBind<T>(out ICommandBinding binding) && 
                _commandFactory.Create(binding.Info) is IExecutableCommand<ICommandPayload> executableCommand)
            {
                return executableCommand.Execute(payload);
            }
            throw new NoSuchCommandException();
        }
    }
}