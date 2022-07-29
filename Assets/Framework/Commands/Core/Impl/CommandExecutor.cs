using Commands.Framework.Commands.BaseCommands;
using Commands.Framework.Commands.Exception;
using Cysharp.Threading.Tasks;

namespace Commands.Framework.Commands.Core.Impl
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

        public UniTask Execute<T>() where T : IExecutableCommand
        {
            if (_commandBinder.TryGetBind<T>(out ICommandBinding binding) && 
                _commandFactory.Create(binding.Info) is T executableCommand)
            {
                return executableCommand.Execute();
            }
            throw new NoSuchCommandException();
        }
        
        public UniTask Execute<T>(ICommandPayload payload) where T : IExecutableCommand<ICommandPayload>
        {
            if (_commandBinder.TryGetBind<T>(out ICommandBinding binding) && 
                _commandFactory.Create(binding.Info) is T executableCommand)
            {
                return executableCommand.Execute(payload);
            }
            throw new NoSuchCommandException();
        }
    }
}